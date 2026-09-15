using Game.Data;
using UnityEngine;

public class Jumper 
{
    private readonly Rigidbody2D _rb;
    private readonly float _jumpForce;

    public Jumper(Rigidbody2D rb, PlayerConfigSo data)
    {
        _rb = rb;
        _jumpForce = data.JumpForce;
    }
}
