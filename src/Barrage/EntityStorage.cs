using System.Runtime.CompilerServices;

namespace Barrage;

internal sealed class EntityStorage
{
    readonly SparseSet<EntitySlot> entityToIndex = new();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Entity Create(in EntitySlot slot)
    {
        var key = entityToIndex.Add(slot);
        return new(key.Index, key.Version);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Destroy(Entity entity)
    {
        var key = new SparseIndex(entity.Index, entity.Version);

        if (!entityToIndex.ContainsIndex(key))
        {
            ThrowHelper.ThrowEntityDoesNotExists();
        }

        entityToIndex.UnsafeRemove(key);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Exists(Entity entity)
    {
        var key = new SparseIndex(entity.Index, entity.Version);
        return entityToIndex.ContainsIndex(key);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref EntitySlot GetSlot(Entity entity)
    {
        var key = new SparseIndex(entity.Index, entity.Version);

        if (!entityToIndex.ContainsIndex(key))
        {
            ThrowHelper.ThrowEntityDoesNotExists();
        }

        return ref entityToIndex.UnsafeGet(key);
    }
}