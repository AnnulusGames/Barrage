namespace Barrage;

public record struct Entity(int Index, int Version)
{
    public static readonly Entity Null = new(-1, 0);
}