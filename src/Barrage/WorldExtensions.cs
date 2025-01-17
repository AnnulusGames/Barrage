using System.Runtime.CompilerServices;

namespace Barrage
{
    public static class WorldExtensions
    {
        public static void ForEach(this World world, EntityQuery query)
        {
            throw new NotImplementedException("The code is not generated correctly.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetComponent<T>(this World world, Entity entity)
            where T : unmanaged
        {
            if (!world.TryGetComponent<T>(entity, out var component)) ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(typeof(T));
            return component;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddComponent<T>(this World world, Entity entity)
            where T : unmanaged
        {
            world.AddComponent<T>(entity, default);
        }
    }
}