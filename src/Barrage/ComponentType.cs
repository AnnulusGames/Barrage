using System.Runtime.InteropServices;

namespace Barrage;

[StructLayout(LayoutKind.Auto)]
public readonly record struct ComponentType : IEquatable<ComponentType>
{
    public required ushort Id { get; init; }
    public required int Size { get; init; }
    public required Type Type { get; init; }
    public required bool IsManagedComponent { get; init; }

    public bool Equals(ComponentType other)
    {
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static implicit operator ComponentType(Type type)
    {
        return ComponentRegistry.GetComponentType(type);
    }
}