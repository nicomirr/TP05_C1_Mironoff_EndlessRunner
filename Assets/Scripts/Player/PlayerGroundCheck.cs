using Game.Data;
using UnityEngine;

public class PlayerGroundCheck 
{
    private readonly Transform _groundCheck;
    private readonly float _groundCheckDistance;
    private readonly LayerMask _groundLayer;

    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    public PlayerGroundCheck(Transform groundCheck, PlayerConfigSo data)
    {
        _groundCheck = groundCheck;
        _groundCheckDistance = data.groundCheckDistance;
        _groundLayer = data.GroundLayer;
    }

    public void UpdateGroundedState()
    {
        _isGrounded = Physics2D.Raycast(_groundCheck.position,Vector3.down,
            _groundCheckDistance, _groundLayer);
    }
}
