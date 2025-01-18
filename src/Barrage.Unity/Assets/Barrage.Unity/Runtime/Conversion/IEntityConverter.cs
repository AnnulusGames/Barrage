namespace Barrage.Unity.Conversion
{
    public interface IEntityConverter
    {
        void AddComponent<T>(in T component = default)
            where T : unmanaged;

        void AddManagedComponent<T>(T component)
            where T : class;

        Entity Convert(World world);
    }

    public interface IComponentConverter
    {
        void Convert(IEntityConverter converter);
    }
}