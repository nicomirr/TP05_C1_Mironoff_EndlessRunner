using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.Spawnable
{
    public class SpawnableController : MonoBehaviour
    {
        [SerializeField] protected SpawnableObjectConfigSo _data;

        [SerializeField] private MonoBehaviour _movementPatternMonoBehaviour;

        private ISpawnableMovementPattern _movementPattern;

        private SpawnableMover _spawnableMover;

        private void Awake()
        {
            _movementPattern = _movementPatternMonoBehaviour as ISpawnableMovementPattern;
            _spawnableMover = new SpawnableMover(_data, GetComponent<Rigidbody2D>(), _movementPattern);
        }

        protected virtual void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopEnvironmentObjects;

            WorldEvents.OnWorldSpeedBroadcast += _spawnableMover.UpdateSpeed;
            WorldEvents.RaiseWorldSpeedRequested();
        }

        private void FixedUpdate()
        {
            _spawnableMover.Move();
        }

        protected virtual void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopEnvironmentObjects;
            WorldEvents.OnWorldSpeedBroadcast -= _spawnableMover.UpdateSpeed;
        }

        private void StopEnvironmentObjects()
        {
            _spawnableMover.TryStopMovement();
        }
    }

}

