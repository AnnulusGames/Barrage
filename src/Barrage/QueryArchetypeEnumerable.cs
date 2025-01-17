namespace Barrage;

public readonly struct QueryArchetypeEnumerable
{
    public ref struct Enumerator(QueryArchetypeEnumerable enumerable)
    {
        public Archetype Current => current;
        Archetype current = default!;
        ReadOnlySpan<Archetype>.Enumerator allArchetypesEnumerator = enumerable.world.Archetypes.GetEnumerator();

        public bool MoveNext()
        {
            if (!allArchetypesEnumerator.MoveNext())
            {
                current = default!;
                return false;
            }

            current = allArchetypesEnumerator.Current;

            var source = enumerable.GetQuerySource();
            if (!current.Match(source)) MoveNext();
            return true;
        }

        public void Dispose()
        {
            enumerable.Dispose();
        }
    }

    readonly World world;
    readonly EntityQuerySource querySource;
    readonly ushort token;

    internal QueryArchetypeEnumerable(World world, EntityQuerySource querySource)
    {
        this.world = world;
        this.querySource = querySource;
        this.token = querySource.Token;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    internal EntityQuerySource GetQuerySource()
    {
        CheckIsDisposed();
        return querySource;
    }

    void Dispose()
    {
        CheckIsDisposed();
        EntityQuerySource.Return(querySource);
    }

    void CheckIsDisposed()
    {
        if (token != querySource.Token) throw new ObjectDisposedException(nameof(QueryArchetypeEnumerable));
    }
}