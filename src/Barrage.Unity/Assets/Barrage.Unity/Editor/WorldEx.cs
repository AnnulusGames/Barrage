namespace Barrage.Unity.Editor
{
    internal static class WorldEx
    {
        public static int IndexOf(World world)
        {
            for (int i = 0; i < World.Worlds.Length; i++)
            {
                if (World.Worlds[i] == world) return i;
            }
            return -1;
        }
    }
}