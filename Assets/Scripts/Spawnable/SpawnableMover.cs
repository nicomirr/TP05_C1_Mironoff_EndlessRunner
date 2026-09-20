using UnityEngine;
using Game.Data;
using Game.Core;


namespace Game.Spawnable
{
    public class SpawnableMover
    {
        private readonly ISpawnableMovementPattern _movementPattern;

        private readonly SpeedType _speedType;

        private readonly Rigidbody2D _rb;

        private readonly float _speedMod;
        private float _speed;

        private bool _canMove;


        public SpawnableMover(SpawnableObjectConfigSo data, Rigidbody2D rb, ISpawnableMovementPattern movementPattern)
        {
            _speedMod = data.SpeedModifierData.SpeedModifier;
            _rb = rb;
            _speedType = data.SpeedModifierData.SpeedType;

            _movementPattern = movementPattern;

            _canMove = true;
        }

        public void Move()
        {
            if (!_canMove) return;

            _rb.linearVelocity = _movementPattern.CalculateVelocity(_speed, _speedMod);
        }

        public void TryStopMovement()
        {
            if (_speedType != SpeedType.Environment) return;

            _canMove = false;
            _rb.linearVelocity = Vector2.zero;
        }

        public void UpdateSpeed(float speed)
        {
            _speed = speed;
        }

    }
}

