namespace Barrage.Tests;

public class WorldTests
{
    [Test]
    public void Test_CreateEntity_1()
    {
        var world = World.Create();

        for (int i = 0; i < 100; i++)
        {
            var entity = world.CreateEntity();
            Assert.IsTrue(world.Exists(entity));
            world.DestroyEntity(entity);
            Assert.IsFalse(world.Exists(entity));
        }
    }

    [Test]
    public void Test_CreateEntity_2()
    {
        var world = World.Create();

        for (int j = 0; j < 10; j++)
        {
            var entities = Enumerable.Range(0, 100)
                .Select(_ => world.CreateEntity())
                .ToArray();

            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                Assert.IsTrue(world.Exists(entity));
                world.DestroyEntity(entity);
                Assert.IsFalse(world.Exists(entity));
            }
        }
    }
}