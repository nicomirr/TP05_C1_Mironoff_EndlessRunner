using UnityEngine;
using Game.Data;

public class SpawnableMover 
{
    private readonly float _speedMod;
    private float _speed;

    private Rigidbody2D _rb;

    public SpawnableMover(SpawnableObjectConfigSo data, Rigidbody2D rb)
    {
        _speedMod = data.SpeedModifierData.SpeedModifier;
        _rb = rb;
    }       

    public void Move()
    {
        _rb.linearVelocity =  Vector2.left * _speed * _speedMod;
    }

    public void UpdateSpeed(float speed)
    {
        _speed = speed;
    }

}
