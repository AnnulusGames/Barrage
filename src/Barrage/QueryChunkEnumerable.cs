namespace Barrage;

public readonly struct QueryChunkEnumerable
{
    public ref struct Enumerator(QueryChunkEnumerable enumerable)
    {
        QueryArchetypeEnumerable.Enumerator archetypeEnumerator = enumerable.archetypes.GetEnumerator();
        ReadOnlySpan<ArchetypeChunk>.Enumerator chunkEnumerator;
        ArchetypeChunk current = default!;

        public ArchetypeChunk Current => current;

        public bool MoveNext()
        {
            if (current == null)
            {
                if (!archetypeEnumerator.MoveNext()) return false;
                chunkEnumerator = archetypeEnumerator.Current.Chunks.GetEnumerator();
            }

            if (!chunkEnumerator.MoveNext())
            {
                current = null!;
                return MoveNext();
            }

            current = chunkEnumerator.Current;
            return true;
        }
    }

    readonly QueryArchetypeEnumerable archetypes;

    internal QueryChunkEnumerable(World world, EntityQuerySource querySource)
    {
        archetypes = new(world, querySource);
    }

    internal EntityQuerySource GetQuerySource()
    {
        return archetypes.GetQuerySource();
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }
}