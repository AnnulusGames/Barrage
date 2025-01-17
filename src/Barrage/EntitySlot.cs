namespace Barrage;

public record struct EntitySlot
{
    public Archetype Archetype { get; set; }
    public int ChunkIndex { get; set; }
    public int EntityIndex { get; set; }

    public readonly ArchetypeChunk GetChunk()
    {
        return Archetype.Chunks[ChunkIndex];
    }
}
