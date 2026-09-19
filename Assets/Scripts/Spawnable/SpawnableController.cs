using UnityEngine;
using Game.Data;
using Game.Events;

public class SpawnableController : MonoBehaviour
{
    [SerializeField] protected SpawnableObjectConfigSo _data;

    private SpawnableMover _spawnableMover;

    private void Awake()
    {
        _spawnableMover = new SpawnableMover(_data, GetComponent<Rigidbody2D>());
    }

    protected virtual void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += StopEnvironmentObjects;

        RunnerEvents.OnWorldSpeedBroadcast += _spawnableMover.UpdateSpeed;
        RunnerEvents.RaiseWorldSpeedRequested();
    }

    private void FixedUpdate()
    {
        _spawnableMover.Move();
    }

    protected virtual void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= StopEnvironmentObjects;
        RunnerEvents.OnWorldSpeedBroadcast -= _spawnableMover.UpdateSpeed;
    }    
    
    private void StopEnvironmentObjects()
    {
        _spawnableMover.TryStopMovement();
    }
}
