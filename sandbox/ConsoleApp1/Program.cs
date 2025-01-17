using Barrage;

var world = World.Create();

world.SubscribeOnComponentAdded((Entity entity, ref Name name) =>
{
    Console.WriteLine("Added: " + name.Value);
});

world.SubscribeOnComponentRemoved((Entity entity, ref Name name) =>
{
    Console.WriteLine("Removed: " + name.Value);
});

var arch = world.CreateArchetype([typeof(Name), typeof(ComponentA), typeof(ComponentB), typeof(ComponentC)]);

var entity1 = world.CreateEntity(arch);
var entity2 = world.CreateEntity(arch);
var entity3 = world.CreateEntity(arch);

world.SetComponent<Name>(entity1, new("E1"));
world.SetComponent<Name>(entity2, new("E2"));
world.SetComponent<Name>(entity3, new("E3"));

var entity4 = world.CreateEntity();
world.AddComponent<Name>(entity4, new("E4"));

foreach (var chunk in world.QueryChunks()
    .WithAll<Name>())
{
    var nameArray = chunk.GetComponentArray<Name>();

    for (int i = 0; i < chunk.Count; i++)
    {
        Console.WriteLine($"{nameArray[i].Value}!");
    }
}

world.RemoveComponent<Name>(entity4);

for (int j = 0; j < 10; j++)
{
    using var query = new EntityQuery()
        .WithAll<Name, ComponentA, ComponentB, ComponentC>();

    world.ForEach(query, (Entity entity, Name name, ref ComponentA componentA, ref ComponentB componentB, ref ComponentC componentC) =>
    {
        componentA.Value += 1;
        componentB.Value += 2;
        componentC.Value += 3;

        Console.WriteLine($"{name.Value}: (A: {componentA.Value}, B: {componentB.Value}, C: {componentC.Value})");
    });

    world.ForEach(query, ForEachMethod);
} 

static void ForEachMethod(Entity entity, Name name, ref ComponentA componentA, ref ComponentB componentB, ref ComponentC componentC)
{
    componentA.Value += 1;
    componentB.Value += 2;
    componentC.Value += 3;

    Console.WriteLine($"{name.Value}: (A: {componentA.Value}, B: {componentB.Value}, C: {componentC.Value})");
}

public record Name(string Value) : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Disposed");
    }
}

public struct ComponentA
{
    public int Value;
}

public struct ComponentB
{
    public int Value;
}

public struct ComponentC
{
    public int Value;
}