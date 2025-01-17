using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Barrage;

public partial class World : IDisposable
{
    public static World Create()
    {
        var world = new World();
        worlds.Add(world);
        return world;
    }

    static FastListCore<World> worlds;
    public static ReadOnlySpan<World> Worlds => worlds.AsSpan();

    readonly EntityStorage entityStorage = new();
    readonly ManagedComponentStorage managedComponentStorage = new();
    readonly WorldEvents events = new();
    FastListCore<Archetype> archetypes;
    bool isDisposed;

    public bool IsDisposed => isDisposed;
    World()
    {
    }

    public Entity CreateEntity()
    {
        return CreateEntity([]);
    }

    public Entity CreateEntity(ReadOnlySpan<ComponentType> componentTypes)
    {
        var archetype = CreateArchetype(componentTypes);
        return CreateEntity(archetype);
    }

    public Entity CreateEntity(Archetype archetype)
    {
        ThrowIfDisposed();

        var lastChunk = archetype.GetOrCreateLastChunk();

        var slot = new EntitySlot
        {
            Archetype = archetype,
            ChunkIndex = archetype.ChunkCount - 1,
            EntityIndex = lastChunk.Count,
        };

        var entity = entityStorage.Create(slot);
        lastChunk.Add(entity);

        events.OnEntityCreated?.Invoke(entity);

        return entity;
    }

    public bool Exists(Entity entity)
    {
        ThrowIfDisposed();

        return entityStorage.Exists(entity);
    }

    public void DestroyEntity(Entity entity)
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);
        var chunk = slot.GetChunk();

        // Release ManagedComponent<T>
        foreach (var type in chunk.Archetype.GetComponentTypes())
        {
            if (type.IsManagedComponent)
            {
                // This is safe because ManagedComponent<T> has a constant size.
                var managedComponent = Unsafe.Add(ref Unsafe.As<byte, ManagedComponent<object>>(ref chunk.GetComponentReference(type)), slot.EntityIndex);
                if (managedComponent.HasValue)
                {
                    managedComponentStorage.RemoveAt(managedComponent.Index);
                }
            }
        }

        if (chunk.Count == 1)
        {
            chunk.Clear();
        }
        else
        {
            chunk.RemoveAtSwapback(slot.EntityIndex, out var swappedEntity);

            // update slot
            ref var swappedEntitySlot = ref entityStorage.GetSlot(swappedEntity);
            swappedEntitySlot.EntityIndex = slot.EntityIndex;
        }

        // clear storage
        entityStorage.Destroy(entity);

        events.OnEntityDestroyed?.Invoke(entity);
    }

    public void AddComponent<T>(Entity entity, in T component)
        where T : unmanaged
    {
        ThrowIfDisposed();

        if (typeof(T) == typeof(Entity)) ThrowHelper.ThrowCannotAddEntityAsComponent();

        ref var slot = ref entityStorage.GetSlot(entity);
        if (slot.Archetype.HasComponent<T>())
        {
            slot.Archetype.UnsafeSetComponent(ref slot, component);
            events.GetOnComponentSet<T>()?.Invoke(entity, ref slot.GetChunk().GetComponentArray<T>()[slot.EntityIndex]);

            return;
        }

        // Create new archtype
        ReadOnlySpan<ComponentType> newComponents = [.. slot.Archetype.GetComponentTypes(), ComponentRegistry.GetComponentType<T>()];
        var newArchetype = CreateArchetype(newComponents);

        // Move Entity
        var srcChunk = slot.GetChunk();
        var dstChunk = newArchetype.GetOrCreateLastChunk();

        dstChunk.Add(entity);
        ArchetypeChunk.CopyTo(srcChunk, dstChunk, slot.EntityIndex, dstChunk.Count - 1);
        ref var dstReference = ref dstChunk.GetComponentArray<T>()[dstChunk.Count - 1];
        dstReference = component;

        MoveEntitySlot(ref slot, srcChunk, dstChunk);

        events.GetOnComponentAdded<T>()?.Invoke(entity, ref dstReference);
    }
    public void RemoveComponent<T>(Entity entity)
        where T : unmanaged
    {
        RemoveComponentCore(entity, out T component);
        events.GetOnComponentRemoved<T>()?.Invoke(entity, ref component);
    }

    void RemoveComponentCore<T>(Entity entity, out T component)
        where T : unmanaged
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);
        if (!slot.Archetype.HasComponent<T>())
        {
            ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(typeof(T));
        }

        // get component for event call
        component = slot.Archetype.GetComponent<T>(ref slot);

        // Create new archetype
        using var newComponents = new PooledList<ComponentType>();
        var componentType = ComponentRegistry.GetComponentType<T>();
        foreach (var type in slot.Archetype.GetComponentTypes())
        {
            if (type != componentType) newComponents.Add(type);
        }

        var newArchetype = CreateArchetype(newComponents.AsSpan());

        // Move entity
        var srcChunk = slot.GetChunk();
        var dstChunk = newArchetype.GetOrCreateLastChunk();

        dstChunk.Add(entity);
        ArchetypeChunk.CopyTo(srcChunk, dstChunk, slot.EntityIndex, dstChunk.Count - 1);

        MoveEntitySlot(ref slot, srcChunk, dstChunk);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void MoveEntitySlot(ref EntitySlot slot, ArchetypeChunk srcChunk, ArchetypeChunk dstChunk)
    {
        // Update slot
        if (srcChunk.Count == 1)
        {
            srcChunk.Clear();
        }
        else
        {
            srcChunk.RemoveAtSwapback(slot.EntityIndex, out var swappedEntity);
            ref var swappedEntitySlot = ref entityStorage.GetSlot(swappedEntity);
            swappedEntitySlot.EntityIndex = slot.EntityIndex;
        }

        slot.Archetype = dstChunk.Archetype;
        slot.ChunkIndex = dstChunk.Archetype.ChunkCount - 1;
        slot.EntityIndex = dstChunk.Count - 1;
    }

    public void SetComponent<T>(Entity entity, in T component)
        where T : unmanaged
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);
        slot.Archetype.SetComponent(ref slot, component);

        events.GetOnComponentSet<T>()?.Invoke(entity, ref slot.GetChunk().GetComponentArray<T>()[slot.EntityIndex]);
    }

    public bool HasComponent<T>(Entity entity)
        where T : unmanaged
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);
        return slot.Archetype.HasComponent<T>();
    }

    public bool TryGetComponent<T>(Entity entity, out T component)
        where T : unmanaged
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);

        if (slot.Archetype.HasComponent<T>())
        {
            component = slot.Archetype.UnsafeGetComponent<T>(ref slot);
            return true;
        }
        else
        {
            component = default;
            return false;
        }
    }

    internal void AddComponentManaged<T>(Entity entity, T component)
        where T : class
    {
        ThrowIfDisposed();

        managedComponentStorage.Add(component, out var index);
        var reference = new ManagedComponent<T>(index);
        AddComponent(entity, reference);
    }

    internal void SetComponentManaged<T>(Entity entity, T component)
        where T : class
    {
        ThrowIfDisposed();

        ref var slot = ref entityStorage.GetSlot(entity);
        slot.Archetype.SetComponentManaged(ref slot, component);

        events.GetOnComponentSet<ManagedComponent<T>>()?.Invoke(entity, ref slot.GetChunk().GetComponentArray<ManagedComponent<T>>()[slot.EntityIndex]);
    }

    internal void RemoveComponentManaged<T>(Entity entity)
        where T : class
    {
        ThrowIfDisposed();

        // TODO: optimize
        var reference = this.GetComponent<ManagedComponent<T>>(entity);
        var component = managedComponentStorage.UnsafeGet<T>(reference);
        managedComponentStorage.RemoveAt(reference);
        RemoveComponentCore<ManagedComponent<T>>(entity, out _);

        events.GetOnComponentRemoved<T>()?.Invoke(entity, ref component!);
    }

    internal bool TryGetComponentManaged<T>(Entity entity, [NotNullWhen(true)] out T? component)
        where T : class
    {
        ThrowIfDisposed();

        if (!TryGetComponent<ManagedComponent<T>>(entity, out var managedComponent))
        {
            component = default;
            return false;
        }

        component = managedComponentStorage.UnsafeGet<T>(managedComponent.Index)!;
        return true;
    }

    public Archetype CreateArchetype(ReadOnlySpan<ComponentType> types)
    {
        ThrowIfDisposed();

        foreach (var archetype in archetypes.AsSpan())
        {
            if (archetype.GetComponentTypes().SequenceEqual(types))
            {
                return archetype;
            }
        }

        var newArchetype = new Archetype(managedComponentStorage, types.ToArray());
        archetypes.Add(newArchetype);
        return newArchetype;
    }

    public ReadOnlySpan<Archetype> Archetypes
    {
        get
        {
            ThrowIfDisposed();
            return archetypes.AsSpan();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QueryArchetypeEnumerable QueryArchetypes()
    {
        ThrowIfDisposed();
        return new QueryArchetypeEnumerable(this, EntityQuerySource.Rent());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QueryArchetypeEnumerable QueryArchetypes(EntityQuery query)
    {
        ThrowIfDisposed();

        var source = EntityQuerySource.Rent();
        query.GetQuerySource().CopyTo(source);
        return new QueryArchetypeEnumerable(this, source);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QueryChunkEnumerable QueryChunks()
    {
        ThrowIfDisposed();
        return new QueryChunkEnumerable(this, EntityQuerySource.Rent());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public QueryChunkEnumerable QueryChunks(EntityQuery query)
    {
        ThrowIfDisposed();

        var source = EntityQuerySource.Rent();
        query.GetQuerySource().CopyTo(source);
        return new QueryChunkEnumerable(this, source);
    }

    public IDisposable SubscribeOnEntityCreated(Action<Entity> handler)
    {
        events.OnEntityCreated += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.OnEntityCreated -= handler;
        });
    }

    public IDisposable SubscribeOnEntityDestoryed(Action<Entity> handler)
    {
        events.OnEntityDestroyed += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.OnEntityDestroyed -= handler;
        });
    }

    public IDisposable SubscribeOnComponentAdded<T>(ComponentEvent<T> handler)
        where T : unmanaged
    {
        events.GetOnComponentAdded<T>() += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.GetOnComponentAdded<T>() -= handler;
        });
    }

    internal IDisposable SubscribeOnComponentAddedManaged<T>(ComponentEvent<T> handler)
        where T : class
    {
        void Handler(Entity entity, ref ManagedComponent<T> componentReference)
        {
            var component = componentReference.HasValue ? managedComponentStorage.UnsafeGet<T>(componentReference.Index) : null;
            handler(entity, ref component!);
        }

        events.GetOnComponentAdded<ManagedComponent<T>>() += Handler;

        return DisposableFactory.Create((world: this, (ComponentEvent<ManagedComponent<T>>)Handler), state =>
        {
            state.world.events.GetOnComponentAdded<ManagedComponent<T>>() -= Handler;
        });
    }

    public IDisposable SubscribeOnComponentSet<T>(ComponentEvent<T> handler)
        where T : unmanaged
    {
        events.GetOnComponentSet<T>() += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.GetOnComponentSet<T>() -= handler;
        });
    }

    internal IDisposable SubscribeOnComponentSetManaged<T>(ComponentEvent<T> handler)
        where T : class
    {
        void Handler(Entity entity, ref ManagedComponent<T> componentReference)
        {
            var component = componentReference.HasValue ? managedComponentStorage.UnsafeGet<T>(componentReference.Index) : null;
            handler(entity, ref component!);
        }

        events.GetOnComponentSet<ManagedComponent<T>>() += Handler;

        return DisposableFactory.Create((world: this, (ComponentEvent<ManagedComponent<T>>)Handler), state =>
        {
            state.world.events.GetOnComponentSet<ManagedComponent<T>>() -= Handler;
        });
    }

    public IDisposable SubscribeOnComponentRemoved<T>(ComponentEvent<T> handler)
        where T : unmanaged
    {
        events.GetOnComponentRemoved<T>() += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.GetOnComponentRemoved<T>() -= handler;
        });
    }

    internal IDisposable SubscribeOnComponentRemovedManaged<T>(ComponentEvent<T> handler)
        where T : class
    {
        events.GetOnComponentRemoved<T>() += handler;
        return DisposableFactory.Create((world: this, handler), state =>
        {
            state.world.events.GetOnComponentRemoved<T>() -= handler;
        });
    }

    public void Dispose()
    {
        ThrowIfDisposed();

        managedComponentStorage.Dispose();
        isDisposed = true;

        var span = worlds.AsSpan();
        for (int i = 0; i < span.Length; i++)
        {
            if (span[i] == this)
            {
                worlds.RemoveAtSwapback(i);
                break;
            }
        }
    }

    void ThrowIfDisposed()
    {
        if (isDisposed) throw new ObjectDisposedException(nameof(World));
    }
}