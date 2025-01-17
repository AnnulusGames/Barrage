namespace Barrage;

public readonly ref struct ManagedComponentArray<T> where T : class
{
    readonly ManagedComponentStorage storage;
    readonly Span<ManagedComponent<T>> reference;
    readonly int length;

    public ref T this[int index] => ref storage.UnsafeGet<T>(reference[index].Index)!;

    public int Length => length;

    internal ManagedComponentArray(ManagedComponentStorage storage, Span<ManagedComponent<T>> reference)
    {
        this.storage = storage;
        this.reference = reference;
        length = reference.Length;
    }

    public Enumerator GetEnumerator()
    {
        return new(this);
    }

    public ref struct Enumerator(ManagedComponentArray<T> array)
    {
        ManagedComponentArray<T> array = array;
        T? current;
        int offset;

        public T Current => current!;

        public bool MoveNext()
        {
            if (offset >= array.Length) return false;

            current = array[offset];
            offset++;

            return true;
        }
    }
}