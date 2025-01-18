using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Barrage;

internal static class ComponentRegistry
{
    public delegate bool TryGetComponentDelegate(World world, Entity entity, out object component);

    static class Cache<T>
        where T : unmanaged
    {
        public static bool Registered;
        public static ComponentType Value;

        public static void Register()
        {
            Registered = true;

            Value = new()
            {
                Id = currentId,
                Size = Unsafe.SizeOf<T>(),
                Type = typeof(T),
                IsManagedComponent = typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(ManagedComponent<>)
            };

            componentTypeCache.TryAdd(typeof(T), Value);

            currentId++;
        }
    }

    public readonly struct NonGenericDelegates
    {
        public required readonly TryGetComponentDelegate TryGetComponent { get; init; }
        public required readonly Action<World, Entity, object> SetComponent { get; init; }
        public required readonly Action<World, Entity, object> AddComponent { get; init; }
        public required readonly Action<World, Entity> RemoveComponent { get; init; }
    }

    static ushort currentId;
    static readonly ConcurrentDictionary<Type, ComponentType> componentTypeCache = [];
    static readonly ConcurrentDictionary<Type, NonGenericDelegates> delegatesCache = [];

    public static ushort Count => currentId;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComponentType GetComponentTypeUnmanaged<T>()
        where T : unmanaged
    {
        if (!Cache<T>.Registered)
        {
            Cache<T>.Register();
            delegatesCache.TryAdd(typeof(T), new()
            {
                TryGetComponent = (World world, Entity entity, out object component) =>
                {
                    var tryResult = world.TryGetComponent<T>(entity, out var comp);
                    component = comp;
                    return tryResult;
                },
                SetComponent = (world, entity, component) => world.SetComponent<T>(entity, (T)component),
                AddComponent = (world, entity, component) => world.AddComponent<T>(entity, (T)component),
                RemoveComponent = (world, entity) => world.RemoveComponent<T>(entity),
            });
        }

        return Cache<T>.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComponentType GetComponentTypeManaged<T>()
        where T : class
    {
        if (!Cache<ManagedComponent<T>>.Registered)
        {
            Cache<ManagedComponent<T>>.Register();

            delegatesCache.TryAdd(typeof(T), new()
            {
                TryGetComponent = (World world, Entity entity, out object component) =>
                {
                    var tryResult = world.TryGetComponent<T>(entity, out var comp);
                    component = comp;
                    return tryResult;
                },
                SetComponent = (world, entity, component) => world.SetComponent<T>(entity, (T)component),
                AddComponent = (world, entity, component) => world.AddComponent<T>(entity, (T)component),
                RemoveComponent = (world, entity) => world.RemoveComponent<T>(entity),
            });
        }

        return Cache<ManagedComponent<T>>.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComponentType GetComponentType(Type type)
    {
        if (type.IsClass)
        {
            var managedComponentType = typeof(ManagedComponent<>).MakeGenericType(type);
            if (componentTypeCache.TryGetValue(managedComponentType, out var componentType)) return componentType;

            Initialize(type);
            return componentTypeCache[managedComponentType];
        }
        else
        {
            if (componentTypeCache.TryGetValue(type, out var componentType)) return componentType;

            Initialize(type);
            return componentTypeCache[type];
        }
    }

    public static NonGenericDelegates GetNonGenericDelegates(Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ManagedComponent<>))
        {
            type = type.GenericTypeArguments[0];
        }

        if (delegatesCache.TryGetValue(type, out var delegates)) return delegates;
        Initialize(type);
        return delegatesCache[type];
    }

    static void Initialize(Type type)
    {
        if (type.IsClass)
        {
            typeof(ComponentRegistry)
                .GetMethod(nameof(GetComponentTypeManaged), BindingFlags.Public | BindingFlags.Static)!
                .MakeGenericMethod(type)
                .Invoke(null, null);
        }
        else
        {
            typeof(ComponentRegistry)
                .GetMethod(nameof(GetComponentTypeUnmanaged), BindingFlags.Public | BindingFlags.Static)!
                .MakeGenericMethod(type)
                .Invoke(null, null);
        }
    }
}