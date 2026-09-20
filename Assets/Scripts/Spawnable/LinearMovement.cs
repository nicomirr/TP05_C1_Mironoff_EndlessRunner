using UnityEngine;

namespace Game.Spawnable
{
    public class LinearMovement : MonoBehaviour, ISpawnableMovementPattern
    {
        public Vector2 CalculateVelocity(float speed, float speedMod)
        {
            return Vector2.left * speed * speedMod;
        }
    }

}
