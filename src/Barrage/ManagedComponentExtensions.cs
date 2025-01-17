using System.Runtime.CompilerServices;

namespace Barrage;

public static class ManagedComponentExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetComponent<T>(this World world, Entity entity)
        where T : class
    {
        if (!world.TryGetComponentManaged<T>(entity, out var component))
        {
            ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(typeof(T));
        }

        return component!;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetComponent<T>(this World world, Entity entity, T component)
        where T : class
    {
        world.SetComponentManaged(entity, component);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddComponent<T>(this World world, Entity entity, T component)
        where T : class
    {
        world.AddComponentManaged(entity, component);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RemoveComponent<T>(this World world, Entity entity)
        where T : class
    {
        world.RemoveComponentManaged<T>(entity);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDisposable SubscribeOnComponentAdded<T>(this World world, ComponentEvent<T> handler)
        where T : class
    {
        return world.SubscribeOnComponentAddedManaged(handler);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDisposable SubscribeOnComponentSet<T>(this World world, ComponentEvent<T> handler)
        where T : class
    {
        return world.SubscribeOnComponentSetManaged(handler);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDisposable SubscribeOnComponentRemoved<T>(this World world, ComponentEvent<T> handler)
        where T : class
    {
        return world.SubscribeOnComponentRemovedManaged(handler);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasComponent<T>(this Archetype archetype)
        where T : class
    {
        return archetype.HasComponent<ManagedComponent<T>>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ManagedComponentArray<T> GetComponentArray<T>(this ArchetypeChunk chunk)
        where T : class
    {
        return new ManagedComponentArray<T>(chunk.Archetype.managedComponentStorage, chunk.GetComponentArray<ManagedComponent<T>>());
    }
}