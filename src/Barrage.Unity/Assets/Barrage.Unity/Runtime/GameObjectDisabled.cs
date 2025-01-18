using System;

namespace Barrage.Unity
{
    public readonly struct GameObjectDisabled : IEquatable<GameObjectDisabled>
    {
        public bool Equals(GameObjectDisabled other) => true;
        public override bool Equals(object obj) => obj is GameObjectDisabled;
        public override int GetHashCode() => 0;
        public override string ToString() => "Disabled";
    }
}