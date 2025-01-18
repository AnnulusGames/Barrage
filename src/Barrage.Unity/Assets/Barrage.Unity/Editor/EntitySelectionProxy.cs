using UnityEngine;

namespace Barrage.Unity.Editor
{
    public sealed class EntitySelectionProxy : ScriptableObject
    {
        public World world;
        public Entity entity;
    }
}