namespace Barrage;

public readonly record struct ManagedComponent<T>
    where T : class
{
    public bool HasValue { get; } = true;
    public int Index { get; }

    public ManagedComponent(int index)
    {
        Index = index;
    }

    public static implicit operator int(ManagedComponent<T> reference)
    {
        return reference.Index;
    }
}