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
        public static object GetComponent(this World world, Entity entity, Type type)
        {
            if (!world.TryGetComponent(entity, type, out var component)) ThrowHelper.ThrowComponentHasNotBeenAddedToEntity(type);
            return component!;
        }
    }
}