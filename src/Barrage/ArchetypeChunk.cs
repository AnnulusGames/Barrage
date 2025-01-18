using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Barrage;

public sealed class ArchetypeChunk(Archetype archetype)
{
    /// <summary>
    /// Chunk size (16KB)
    /// </summary>
    public const int Size = 1024 * 16;

    readonly byte[] bytes = new byte[Size];
    int tail;
    public Archetype Archetype { get; } = archetype;

    public int Capacity => Archetype.ChunkCapacity;
    public int Count => tail;

    internal bool IsFull => Capacity == Count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Entity> GetEntities()
    {
        return MemoryMarshal.CreateSpan(ref GetEntityReference(), tail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> GetComponentArray<T>() where T : unmanaged
    {
        return MemoryMarshal.CreateSpan(ref GetComponentReference<T>(), tail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref Entity GetEntityReference()
    {
        return ref Unsafe.As<byte, Entity>(ref MemoryMarshalEx.GetArrayDataReference(bytes));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref byte GetComponentReference(ComponentType componentType)
    {
        var offset = Archetype.GetComponentDataPosition(componentType);
        ref var componentRef = ref Unsafe.Add(ref MemoryMarshalEx.GetArrayDataReference(bytes), offset);
        return ref componentRef;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ref T GetComponentReference<T>() where T : unmanaged
    {
        var componentType = ComponentRegistry.GetComponentTypeUnmanaged<T>();
        ref var componentRef = ref GetComponentReference(componentType);
        return ref Unsafe.As<byte, T>(ref componentRef);
    }

    internal void Add(Entity entity)
    {
        if (tail == Capacity) ThrowHelper.ThrowChunkIsFull();
        Unsafe.Add(ref GetEntityReference(), tail) = entity;
        tail++;
    }

    internal void RemoveAtSwapback(int index, out Entity swappedEntity)
    {
        if (index < 0 || index >= tail) ThrowHelper.ThrowIndexOutOfRangeException();
        tail--;
        swappedEntity = Unsafe.Add(ref GetEntityReference(), index) = Unsafe.Add(ref GetEntityReference(), tail);

        foreach (var type in Archetype.GetComponentTypes())
        {
            ref var srcComponentRef = ref Unsafe.Add(ref GetComponentReference(type), tail * type.Size);
            ref var dstComponentRef = ref Unsafe.Add(ref GetComponentReference(type), index * type.Size);

            if (type.IsManagedComponent)
            {
                Archetype.managedComponentStorage.RemoveAt(Unsafe.As<byte, ManagedComponent<object>>(ref dstComponentRef).Index);
            }

            Unsafe.CopyBlock(ref dstComponentRef, ref srcComponentRef, (uint)type.Size);
        }
    }

    internal void Clear()
    {
        tail = 0;
    }

    public static void CopyTo(ArchetypeChunk src, ArchetypeChunk dst, int srcIndex, int dstIndex)
    {
        if (srcIndex >= src.Count) ThrowHelper.ThrowOutOfRangeException();
        if (dstIndex >= dst.Count) ThrowHelper.ThrowOutOfRangeException();

        Unsafe.Add(ref dst.GetEntityReference(), dstIndex) = Unsafe.Add(ref src.GetEntityReference(), srcIndex);

        var types = dst.Archetype.Match(src.Archetype)
            ? dst.Archetype.GetComponentTypes()
            : src.Archetype.GetComponentTypes();

        foreach (var type in types)
        {
            if (!src.Archetype.HasComponent(type)) continue;
            if (!dst.Archetype.HasComponent(type)) continue;
            ref var srcComponentRef = ref Unsafe.Add(ref src.GetComponentReference(type), srcIndex * type.Size);
            ref var dstComponentRef = ref Unsafe.Add(ref dst.GetComponentReference(type), dstIndex * type.Size);
            Unsafe.CopyBlock(ref dstComponentRef, ref srcComponentRef, (uint)type.Size);
        }
    }
}
