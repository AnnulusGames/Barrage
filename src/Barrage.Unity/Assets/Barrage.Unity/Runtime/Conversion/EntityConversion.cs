using System;
using System.Collections.Generic;
using UnityEngine;
using UnityComponent = UnityEngine.Component;

namespace Barrage.Unity.Conversion
{
    public static class EntityConversion
    {
        class Converter : IEntityConverter
        {
            static readonly Stack<Converter> pool = new();

            public static Converter Rent()
            {
                if (!pool.TryPop(out var result)) result = new();
                return result;
            }

            public static void Return(Converter converter)
            {
                converter.componentTypes.Clear();
                converter.convertActions.Clear();

                pool.Push(converter);
            }

            // TODO: avoid boxing
            FastListCore<ComponentType> componentTypes;
            FastListCore<(object Component, Action<World, Entity, object> Action)> convertActions;

            public void AddComponent<T>(in T component = default) where T : unmanaged
            {
                componentTypes.Add(typeof(T));
                convertActions.Add((component, (world, entity, component) =>
                {
                    world.SetComponent(entity, (T)component);
                }
                ));
            }

            public void AddManagedComponent<T>(T component) where T : class
            {
                componentTypes.Add(typeof(T));
                convertActions.Add((component, (world, entity, component) =>
                {
                    world.SetComponent(entity, (T)component);
                }
                ));
            }

            public Entity Convert(World world)
            {
                var archetype = world.CreateArchetype(componentTypes.AsSpan());
                var entity = world.CreateEntity(archetype);

                foreach ((var component, var action) in convertActions.AsSpan())
                {
                    action(world, entity, component);
                }

                return entity;
            }
        }

        static readonly List<UnityComponent> components = new();

        public static World DefaultWorld { get; set; }

#if !BARRAGE_UNITY_DISABLE_AUTOMATIC_BOOTSTRAP
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Init()
        {
            var world = DefaultWorld = World.Create();

            Application.quitting += () =>
            {
                if (!world.IsDisposed) world.Dispose();
            };
        }
#endif

        public static Entity Convert(GameObject gameObject)
        {
            return Convert(gameObject, DefaultWorld, EntityConversionOptions.Default);
        }

        public static Entity Convert(GameObject gameObject, World world, EntityConversionOptions options)
        {
            components.Clear();
            gameObject.GetComponents(components);

            var converter = Converter.Rent();

            if (options.ConversionMode == ConversionMode.SyncWithEntity)
            {
                converter.AddManagedComponent(gameObject);
                converter.AddComponent(new EntityName(gameObject.name));
            }

            for (int i = 0; i < components.Count; i++)
            {
                var component = components[i];

                if (component is SyncWithEntity)
                {
                    throw new InvalidOperationException("A GameObject that has already been synchronized with an entity cannot be converted again.");
                }

                if (component is IComponentConverter componentConverter)
                {
                    try
                    {
                        componentConverter.Convert(converter);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogException(ex);
                    }
                }
                else if (options.ConversionMode == ConversionMode.SyncWithEntity && options.ConvertUnityComponents)
                {
                    converter.AddManagedComponent((object)component);
                }
            }

            var entity = converter.Convert(world);

            if (options.ConversionMode == ConversionMode.ConvertAndDestroy)
            {
                UnityEngine.Object.Destroy(gameObject);
            }
            else
            {
                var syncWithEntity = gameObject.AddComponent<SyncWithEntity>();
                syncWithEntity.World = world;
                syncWithEntity.Entity = entity;
            }

            Converter.Return(converter);

            return entity;
        }

        public static bool TryGetEntity(GameObject gameObject, out Entity entity)
        {
            if (gameObject.TryGetComponent<SyncWithEntity>(out var syncWithEntity))
            {
                entity = syncWithEntity.Entity;
                return true;
            }

            entity = default;
            return false;
        }
    }
}