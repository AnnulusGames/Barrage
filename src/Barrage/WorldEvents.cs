using System.Runtime.CompilerServices;
using LitMotion;

namespace Barrage;

public delegate void ComponentEvent<T>(Entity entity, ref T component);

internal delegate void CallComponentEvent(World world, Entity entity);

internal sealed class WorldEvents
{
    Action<Entity>? onEntityCreated;
    Action<Entity>? onEntityDestroyed;

    object?[] onComponentAddedEvents = new object[32];
    object?[] onComponentRemovedEvents = new object[32];

    object?[] callComponentAddedEventHandlers = new object[32];
    object?[] callComponentRemovedEventHandlers = new object[32];

    public ref Action<Entity>? OnEntityCreated => ref onEntityCreated;
    public ref Action<Entity>? OnEntityDestroyed => ref onEntityDestroyed;

    public ref ComponentEvent<T>? GetOnComponentAdded<T>()
    {
        var componentType = ComponentRegistry.GetComponentType(typeof(T));
        ArrayHelper.EnsureCapacity(ref onComponentAddedEvents, componentType.Id + 1);
        ref var eventHandler = ref onComponentAddedEvents[componentType.Id];
        return ref Unsafe.As<object?, ComponentEvent<T>?>(ref eventHandler);
    }

    public ref CallComponentEvent? GetCallComponentAddedHandler(ComponentType componentType)
    {
        ArrayHelper.EnsureCapacity(ref callComponentAddedEventHandlers, componentType.Id + 1);
        ref var eventHandler = ref callComponentAddedEventHandlers[componentType.Id];
        return ref Unsafe.As<object?, CallComponentEvent?>(ref eventHandler);
    }

    public ref ComponentEvent<T>? GetOnComponentRemoved<T>()
    {
        var componentType = ComponentRegistry.GetComponentType(typeof(T));
        ArrayHelper.EnsureCapacity(ref onComponentRemovedEvents, componentType.Id + 1);
        ref var eventHandler = ref onComponentRemovedEvents[componentType.Id];
        return ref Unsafe.As<object?, ComponentEvent<T>?>(ref eventHandler);
    }

    public ref CallComponentEvent? GetCallComponentRemovedHandler(ComponentType componentType)
    {
        ArrayHelper.EnsureCapacity(ref callComponentRemovedEventHandlers, componentType.Id + 1);
        ref var eventHandler = ref callComponentRemovedEventHandlers[componentType.Id];
        return ref Unsafe.As<object?, CallComponentEvent?>(ref eventHandler);
    }
}