using System.Runtime.CompilerServices;

namespace Barrage;

internal sealed class ManagedComponentStorage : IDisposable
{
    FastStackCore<int> freeIndex;
    object?[] array;
    int count;

    const int InitialCapacity = 512;

    public int Count => count;

    public ManagedComponentStorage()
    {
        array = new object[InitialCapacity];
        for (int i = 0; i < InitialCapacity; i++)
        {
            freeIndex.Push(i);
        }
    }

    public void Add(object item, out int index)
    {
        if (freeIndex.TryPop(out index))
        {
            array[index] = item;
            count++;
        }
        else
        {
            index = array.Length;
            for (int i = count * 2 - 1; i >= index; i--)
            {
                freeIndex.Push(i);
            }

            Array.Resize(ref array, count * 2);
            array[index] = item;
        }
    }

    public void RemoveAt(int index)
    {
        if (array == null || count == 0) throw new IndexOutOfRangeException();

        ref var item = ref array[index];
        if (item is IDisposable disposable) disposable.Dispose();
        item = null;
        count--;

        freeIndex.Push(index);
    }

    public Span<object?> AsSpan()
    {
        return new(array, 0, count);
    }

    public ref T? UnsafeGet<T>(int index) where T : class
    {
        ref var element = ref Unsafe.Add(ref MemoryMarshalEx.GetArrayDataReference(array), index);
        return ref Unsafe.As<object?, T?>(ref element);
    }

    public void Dispose()
    {
        foreach (var obj in array)
        {
            if (obj is IDisposable disposable) disposable.Dispose();
        }

        array.AsSpan().Clear();
        count = -1;
    }
}