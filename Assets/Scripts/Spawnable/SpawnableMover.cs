using UnityEngine;
using Game.Data;
using Game.Core;

public class SpawnableMover 
{
    private readonly SpeedType _speedType;

    private readonly Rigidbody2D _rb;

    private readonly float _speedMod;
    private float _speed;

    private bool _canMove;


    public SpawnableMover(SpawnableObjectConfigSo data, Rigidbody2D rb)
    {
        _speedMod = data.SpeedModifierData.SpeedModifier;
        _rb = rb;
        _speedType = data.SpeedModifierData.SpeedType;

        _canMove = true;
    }       

    public void Move()
    {
        if (!_canMove) return;

        _rb.linearVelocity =  Vector2.left * _speed * _speedMod;
    }

    public void TryStopMovement()
    {
        Debug.Log(_speedType.ToString());

        if (_speedType != SpeedType.Environment) return; 

        _canMove = false;
        _rb.linearVelocity = Vector2.zero;
    }
    
    public void UpdateSpeed(float speed)
    {
        _speed = speed;
    }

}
