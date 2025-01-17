namespace Barrage.Tests;

public class ArchetypeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_GetSet_Component()
    {
        var entityStorage = new EntityStorage();
        var archetype = new Archetype(new(), [ComponentRegistry.GetComponentType<ComponentA>(), ComponentRegistry.GetComponentType<ManagedComponent<ManagedComponentA>>()]);

        var entity1 = entityStorage.Create(new()
        {
            Archetype = archetype,
            ChunkIndex = 0,
            EntityIndex = 0
        });

        var entity2 = entityStorage.Create(new()
        {
            Archetype = archetype,
            ChunkIndex = 0,
            EntityIndex = 1
        });

        ref var entity1Slot = ref entityStorage.GetSlot(entity1);
        ref var entity2Slot = ref entityStorage.GetSlot(entity2);

        archetype.GetOrCreateLastChunk().Add(entity1);
        archetype.GetOrCreateLastChunk().Add(entity2);

        archetype.SetComponent(ref entity1Slot, new ComponentA()
        {
            Foo = 1,
            Bar = 2.3f,
        });

        archetype.SetComponentManaged(ref entity1Slot, new ManagedComponentA()
        {
            Foo = "Hello!"
        });

        archetype.SetComponent(ref entity2Slot, new ComponentA()
        {
            Foo = 4,
            Bar = 5.6f,
        });

        archetype.SetComponentManaged(ref entity2Slot, new ManagedComponentA()
        {
            Foo = "Goodbye!"
        });

        Assert.That(archetype.GetComponent<ComponentA>(ref entity1Slot).Foo, Is.EqualTo(1));
        Assert.That(archetype.GetComponent<ComponentA>(ref entity1Slot).Bar, Is.EqualTo(2.3f));
        Assert.That(archetype.GetComponentManaged<ManagedComponentA>(ref entity1Slot)!.Foo, Is.EqualTo("Hello!"));

        Assert.That(archetype.GetComponent<ComponentA>(ref entity2Slot).Foo, Is.EqualTo(4));
        Assert.That(archetype.GetComponent<ComponentA>(ref entity2Slot).Bar, Is.EqualTo(5.6f));
        Assert.That(archetype.GetComponentManaged<ManagedComponentA>(ref entity2Slot)!.Foo, Is.EqualTo("Goodbye!"));
    }
}