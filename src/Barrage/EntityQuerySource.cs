using System.Collections.Concurrent;

namespace Barrage
{
    internal sealed class EntityQuerySource
    {
        static readonly ConcurrentStack<EntityQuerySource> pool = new();

        public static EntityQuerySource Rent()
        {
            if (!pool.TryPop(out var source))
            {
                source = new();
            }

            return source;
        }

        public static void Return(EntityQuerySource source)
        {
            source.Reset();
            pool.Push(source);
        }

        public ushort Token => token;

        ushort token;
        readonly BitSet all = new(MaxBitCount);
        readonly BitSet any = new(MaxBitCount);
        readonly BitSet none = new(MaxBitCount);

        public BitSet All => all;
        public BitSet Any => any;
        public BitSet None => none;

        EntityQuerySource()
        {
        }

        void Reset()
        {
            all.SetAll(false);
            any.SetAll(false);
            none.SetAll(false);
            token++;
        }

        static int MaxBitCount => (int)MathF.Floor(ComponentRegistry.Count / 8f);

        public void EnsureBitSetCapacity(int capacity)
        {
            all.EnsureCapacity(capacity);
            any.EnsureCapacity(capacity);
            none.EnsureCapacity(capacity);
        }

        public void CopyTo(EntityQuerySource destination)
        {
            destination.EnsureBitSetCapacity(MaxBitCount);
            all.CopyTo(destination.all);
            any.CopyTo(destination.any);
            none.CopyTo(destination.none);
        }
    }
}