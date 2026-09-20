using UnityEngine;

namespace Game.Spawnable
{
    public interface ISpawnableMovementPattern
    {
        public Vector2 CalculateVelocity(float speed, float speedMod);
    }
}

