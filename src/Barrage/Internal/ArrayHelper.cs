using System.Runtime.CompilerServices;

namespace LitMotion
{
    internal static class ArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnsureCapacity<T>(ref T[] array, int minimumCapacity)
        {
            if (array == null)
            {
                array = new T[minimumCapacity];
            }
            else
            {
                var l = array.Length;
                if (l >= minimumCapacity) return;

                while (l < minimumCapacity)
                {
                    l *= 2;
                }

                Array.Resize(ref array, l);
            }
        }
    }
}