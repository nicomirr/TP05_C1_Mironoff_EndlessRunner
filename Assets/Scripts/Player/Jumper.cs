using Game.Data;
using UnityEngine;

namespace Game.Player
{
    public class Jumper
    {
        private readonly Rigidbody2D _rb;
        private readonly float _jumpForce;

        public Jumper(Rigidbody2D rb, PlayerConfigSo data)
        {
            _rb = rb;
            _jumpForce = data.JumpForce;
        }

        public void Jump()
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}

