using System.Runtime.CompilerServices;

namespace Barrage;

internal struct SparseSetEntryCollection
{
    public record struct Entry
    {
        public int? Next { get; set; }
        public int Index { get; set; }
        public int DenseIndex { get; set; }
        public int Version { get; set; }
    }

    public SparseSetEntryCollection(int initialCapacity)
    {
        entries = new Entry[initialCapacity];
        Reset();
    }

    Entry[] entries;
    int? freeEntry;

    public Entry this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => entries[index];
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => entries[index] = value;
    }

    public void EnsureCapacity(int capacity)
    {
        var currentLength = entries.Length;
        if (currentLength >= capacity) return;

        Array.Resize(ref entries, capacity);
        for (int i = currentLength; i < entries.Length; i++)
        {
            entries[i] = new() { Next = i == capacity - 1 ? freeEntry : i + 1, DenseIndex = -1, Version = 1 };
        }
        freeEntry = currentLength;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Entry Alloc(int denseIndex)
    {
        // Ensure array capacity
        if (freeEntry == null)
        {
            var currentLength = entries.Length;
            EnsureCapacity(entries.Length * 2);
            freeEntry = currentLength;
        }

        // Find free entry
        var entryIndex = freeEntry.Value;
        var entry = entries[entryIndex];
        freeEntry = entry.Next;
        entry.Next = null;
        entry.Index = entryIndex;
        entry.DenseIndex = denseIndex;
        entries[entryIndex] = entry;

        return entry;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Free(int index)
    {
        var entry = entries[index];
        entry.Next = freeEntry;
        entry.Version++;
        entries[index] = entry;
        freeEntry = index;
    }

    public void Reset()
    {
        for (int i = 0; i < entries.Length; i++)
        {
            entries[i] = new() { Next = i == entries.Length - 1 ? null : i + 1, DenseIndex = -1, Version = 1 };
        }

        freeEntry = 0;
    }

    public int Capacity => entries.Length;
}
