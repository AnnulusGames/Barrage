using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Barrage;

public static class ComponentRegistry
{
    static class Cache<T>
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

            cacheNonGeneric.TryAdd(typeof(T), Value);

            currentId++;
        }
    }

    static ushort currentId;
    static readonly ConcurrentDictionary<Type, ComponentType> cacheNonGeneric = [];

    public static ushort Count => currentId;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ComponentType GetComponentType<T>()
        where T : unmanaged
    {
        if (!Cache<T>.Registered) Cache<T>.Register();
        return Cache<T>.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ComponentType GetComponentType(Type type)
    {
        if (type.IsClass)
        {
            var managedComponentType = typeof(ManagedComponent<>).MakeGenericType(type);
            if (cacheNonGeneric.TryGetValue(managedComponentType, out var componentType)) return componentType;

            typeof(Cache<>).MakeGenericType(managedComponentType)
                .GetMethod("Register", BindingFlags.Public | BindingFlags.Static)!
                .Invoke(null, null);
        }
        else
        {
            if (cacheNonGeneric.TryGetValue(type, out var componentType)) return componentType;

            typeof(Cache<>).MakeGenericType(type)
                .GetMethod("Register", BindingFlags.Public | BindingFlags.Static)!
                .Invoke(null, null);
        }

        return cacheNonGeneric[type];
    }
}