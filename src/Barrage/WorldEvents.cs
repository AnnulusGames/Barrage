using System.Runtime.CompilerServices;
using LitMotion;

namespace Barrage;

public delegate void ComponentEvent<T>(Entity entity, ref T component);

internal sealed class WorldEvents
{
    Action<Entity>? onEntityCreated;
    Action<Entity>? onEntityDestroyed;
    object?[] onComponentAddedEvents = new object[32];
    object?[] onComponentRemovedEvents = new object[32];

    public ref Action<Entity>? OnEntityCreated => ref onEntityCreated;
    public ref Action<Entity>? OnEntityDestroyed => ref onEntityDestroyed;

    public ref ComponentEvent<T>? GetOnComponentAdded<T>()
    {
        var componentType = ComponentRegistry.GetComponentType(typeof(T));
        ArrayHelper.EnsureCapacity(ref onComponentAddedEvents, componentType.Id + 1);
        ref var eventHandler = ref onComponentAddedEvents[componentType.Id];
        return ref Unsafe.As<object?, ComponentEvent<T>?>(ref eventHandler);
    }

    public ref ComponentEvent<T>? GetOnComponentRemoved<T>()
    {
        var componentType = ComponentRegistry.GetComponentType(typeof(T));
        ArrayHelper.EnsureCapacity(ref onComponentRemovedEvents, componentType.Id + 1);
        ref var eventHandler = ref onComponentRemovedEvents[componentType.Id];
        return ref Unsafe.As<object?, ComponentEvent<T>?>(ref eventHandler);
    }
}