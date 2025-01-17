namespace Barrage.Tests;

public record struct ComponentA
{
    public int Foo;
    public float Bar;
}

public record ManagedComponentA
{
    public string Foo = "";
}