using Game.Data;
using Game.Events;
using UnityEngine;

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
        RunnerEvents.OnWorldSpeedBroadcast += _spawnableMover.UpdateSpeed;
        RunnerEvents.RaiseWorldSpeedRequested();
    }

    private void FixedUpdate()
    {
        _spawnableMover.Move();
    }

    protected virtual void OnDisable()
    {
        RunnerEvents.OnWorldSpeedBroadcast -= _spawnableMover.UpdateSpeed;
    }    
    
}
