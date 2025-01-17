using System.Runtime.CompilerServices;

namespace Barrage;

internal record struct SparseIndex(int Index, int Version);

internal sealed class SparseSet<T>
{
    const int InitialCapacity = 8;

    // Entry
    SparseSetEntryCollection entries = new(32);

    // Data
    int?[] toEntryIndex = new int?[InitialCapacity];
    T[] values = new T[InitialCapacity];

    int tail;

    public int Count => tail;

    public ref T this[SparseIndex key]
    {
        get
        {
            CheckIndex(key);
            return ref values[entries[key.Index].DenseIndex];
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T UnsafeGet(SparseIndex key)
    {
        return ref values[entries[key.Index].DenseIndex];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> AsSpan()
    {
        return values.AsSpan(0, tail);
    }

    public SparseIndex Add(T item)
    {
        if (tail == values.Length)
        {
            var newLength = tail * 2;
            Array.Resize(ref toEntryIndex, newLength);
            Array.Resize(ref values, newLength);
        }

        var entry = entries.Alloc(tail);

        toEntryIndex[tail] = entry.Index;
        values[tail] = item;

        tail++;

        return new SparseIndex(entry.Index, entry.Version);
    }

    public void Set(SparseIndex key, T value)
    {
        CheckIndex(key);

        var denseIndex = entries[key.Index].DenseIndex;
        values[denseIndex] = value;
    }

    public void Remove(SparseIndex key)
    {
        CheckIndex(key);
        RemoveCore(entries[key.Index].DenseIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void UnsafeRemove(SparseIndex key)
    {
        RemoveCore(entries[key.Index].DenseIndex);
    }

    public bool ContainsIndex(SparseIndex key)
    {
        if (key.Index < 0 || entries.Capacity <= key.Index) return false;

        var entry = entries[key.Index];
        var denseIndex = entry.DenseIndex;
        if (denseIndex < 0 || denseIndex >= values.Length)
        {
            return false;
        }

        var version = entry.Version;
        if (version <= 0 || version != key.Version)
        {
            return false;
        }

        return true;
    }

    public void Clear()
    {
        entries.Reset();
        toEntryIndex.AsSpan().Clear();
        values.AsSpan().Clear();
        tail = 0;
    }

    public void EnsureCapacity(int capacity)
    {
        if (capacity > values.Length)
        {
            Array.Resize(ref toEntryIndex, capacity);
            Array.Resize(ref values, capacity);
            entries.EnsureCapacity(capacity);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void CheckIndex(SparseIndex key)
    {
        if (!ContainsIndex(key)) ThrowHelper.ThrowOutOfRangeException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void RemoveCore(int denseIndex)
    {
        tail--;

        // swap elements
        values[denseIndex] = values[tail];
        values[tail] = default!;

        // swap entry indexes
        var prevEntryIndex = toEntryIndex[denseIndex];
        var currentEntryIndex = toEntryIndex[denseIndex] = toEntryIndex[tail];
        toEntryIndex[tail] = default;

        // update entry
        if (currentEntryIndex != null)
        {
            var index = (int)currentEntryIndex;
            var entry = entries[index];
            entry.DenseIndex = denseIndex;
            entries[index] = entry;
        }

        // free entry
        if (prevEntryIndex != null)
        {
            entries.Free((int)prevEntryIndex);
        }
    }
}