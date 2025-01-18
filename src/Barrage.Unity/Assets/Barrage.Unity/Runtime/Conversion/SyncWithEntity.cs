using System.Runtime.CompilerServices;
using UnityEngine;

namespace Barrage.Unity.Conversion
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public sealed class SyncWithEntity : MonoBehaviour
    {
        internal World World { get; set; }
        internal Entity Entity { get; set; }

        void OnEnable()
        {
            if (!IsEntityExists()) return;

            if (World.HasComponent<GameObjectDisabled>(Entity))
            {
                World.RemoveComponent<GameObjectDisabled>(Entity);
            }
        }

        void OnDisable()
        {
            if (!IsEntityExists()) return;

            if (!World.HasComponent<GameObjectDisabled>(Entity))
            {
                World.AddComponent<GameObjectDisabled>(Entity);
            }
        }

        void OnDestroy()
        {
            if (IsEntityExists())
            {
                World.DestroyEntity(Entity);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Entity GetEntity()
        {
            return Entity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEntityExists()
        {
            if (World == null || World.IsDisposed) return false;
            return World.Exists(Entity);
        }
    }
}