using System.Runtime.CompilerServices;

namespace Barrage;

public sealed class Archetype
{
    internal readonly ManagedComponentStorage managedComponentStorage;

    readonly ComponentSet componentSet;
    readonly Dictionary<int, int> componentIdToDataPosition = [];
    readonly int chunkCapacity;

    FastListCore<ArchetypeChunk> chunks;

    public int ChunkCount => chunks.Length;
    public int ChunkCapacity => chunkCapacity;

    internal ComponentSet ComponentSet => componentSet;

    internal Archetype(ManagedComponentStorage managedComponentStorage, ComponentType[] types)
    {
        this.managedComponentStorage = managedComponentStorage;
        this.componentSet = new(types);

        var byteSize = 0;
        byteSize += Unsafe.SizeOf<Entity>();
        foreach (var type in types)
        {
            byteSize += type.Size;
        }

        chunkCapacity = ArchetypeChunk.Size / byteSize;

        var offset = Unsafe.SizeOf<Entity>() * chunkCapacity;
        foreach (var type in types)
        {
            componentIdToDataPosition.Add(type.Id, offset);
            offset += type.Size * chunkCapacity;
        }
    }

    public ReadOnlySpan<ArchetypeChunk> Chunks
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return chunks.AsSpan();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<ComponentType> GetComponentTypes()
    {
        return componentSet.AsSpan();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Match(EntityQuery query)
    {
        return Match(query.GetQuerySource());
    }

    internal bool Match(EntityQuerySource source)
    {
        if (!source.All.HasAll(componentSet.bitSet))
        {
            return false;
        }

        if (!source.Any.HasAny(componentSet.bitSet))
        {
            return false;
        }

        if (!source.None.HasNone(componentSet.bitSet))
        {
            return false;
        }

        return true;
    }

    internal bool Match(Archetype archetype)
    {
        return archetype.componentSet.IsSubsetOf(componentSet);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(ReadOnlySpan<ComponentType> types)
    {
        var componentSet = new ComponentSet(types.ToArray());
        return componentSet.IsSubsetOf(this.componentSet);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasComponent<T>()
        where T : unmanaged
    {
        return componentIdToDataPosition.ContainsKey(ComponentRegistry.GetComponentTypeUnmanaged<T>().Id);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasComponent(ComponentType type)
    {
        return componentIdToDataPosition.ContainsKey(type.Id);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T GetComponent<T>(ref EntitySlot slot)
        where T : unmanaged
    {
        if (!HasComponent<T>()) ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(typeof(T));
        return Unsafe.Add(ref Chunks[slot.ChunkIndex].GetComponentArray<T>()[slot.EntityIndex], slot.EntityIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T UnsafeGetComponent<T>(ref EntitySlot slot)
        where T : unmanaged
    {
        return Unsafe.Add(ref Chunks[slot.ChunkIndex].GetComponentArray<T>()[slot.EntityIndex], slot.EntityIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal T? GetComponentManaged<T>(ref EntitySlot slot)
        where T : class
    {
        var reference = GetComponent<ManagedComponent<T>>(ref slot);
        if (!reference.HasValue) return null;
        return managedComponentStorage.UnsafeGet<T>(reference.Index)!;
    }

    internal void SetComponentManaged<T>(ref EntitySlot slot, in T value)
        where T : class
    {
        var reference = GetComponent<ManagedComponent<T>>(ref slot);

        if (reference.HasValue)
        {
            managedComponentStorage.UnsafeGet<T>(reference.Index) = value;
        }
        else
        {
            managedComponentStorage.Add(value, out var index);
            reference = new(index);
            SetComponent(ref slot, reference);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void SetComponent<T>(ref EntitySlot slot, in T value)
        where T : unmanaged
    {
        if (!HasComponent<T>()) ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(typeof(T));
        Unsafe.Add(ref Chunks[slot.ChunkIndex].GetComponentReference<T>(), slot.EntityIndex) = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void UnsafeSetComponent<T>(ref EntitySlot slot, in T value)
        where T : unmanaged
    {
        Unsafe.Add(ref Chunks[slot.ChunkIndex].GetComponentReference<T>(), slot.EntityIndex) = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ArchetypeChunk GetOrCreateLastChunk()
    {
        var lastChunk = chunks.Length == 0 ? null : chunks[^1];
        if (lastChunk == null || lastChunk.IsFull)
        {
            lastChunk = new ArchetypeChunk(this);
            chunks.Add(lastChunk);
        }

        return lastChunk;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal int GetComponentDataPosition(ComponentType type)
    {
        if (!componentIdToDataPosition.TryGetValue(type.Id, out var position))
        {
            ThrowHelper.ThrowArchetypeDoesNotHaveComponent(type.Type);
        }
        return position;
    }

    internal void MoveAllEntitiesTo(Archetype destination)
    {

    }
}