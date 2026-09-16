using UnityEngine;
using Game.Events;

public class SpawnablesMover : MonoBehaviour
{
    private float _baseSpeed;
    //IMPLEMENTAR ESTO, CADA OBJETO TIENE MODIFICADOR DE SPEED
    private float _speedMod = 1f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        RunnerEvents.OnWorldSpeedBroadcast += UpdateBaseSpeed;
        RunnerEvents.RaiseWorldSpeedRequested();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity =  Vector2.left * _baseSpeed * _speedMod;
    }

    private void OnDisable()
    {
        RunnerEvents.OnWorldSpeedBroadcast -= UpdateBaseSpeed;
    }

    private void UpdateBaseSpeed(float speed)
    {
        _baseSpeed = speed;
    }

}
