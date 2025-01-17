namespace Barrage;

// TODO: cache ComponentSet

internal sealed class ComponentSet
{
    readonly ComponentType[] types;
    internal readonly BitSet bitSet;

    public ComponentSet(ComponentType[] types)
    {
        this.types = types;

        bitSet = new BitSet((int)MathF.Floor(ComponentRegistry.Count / 8f));
        foreach (var type in types)
        {
            bitSet.Set(type.Id, true);
        }
    }

    public ReadOnlySpan<ComponentType> AsSpan()
    {
        return types;
    }

    public bool IsSubsetOf(ComponentSet other)
    {
        return bitSet.HasAll(other.bitSet);
    }
}