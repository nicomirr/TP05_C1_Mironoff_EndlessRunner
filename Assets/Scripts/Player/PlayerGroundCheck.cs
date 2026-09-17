using Game.Data;
using System;
using UnityEngine;

public class PlayerGroundCheck 
{
    private readonly Transform _groundCheck;
    private readonly float _groundCheckDistance;
    private readonly LayerMask _groundLayer;

    public event Action OnJustLanded;

    private bool _isGroundedPreviousState;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;
    
    public PlayerGroundCheck(Transform groundCheck, PlayerConfigSo data)
    {
        _groundCheck = groundCheck;
        _groundCheckDistance = data.groundCheckDistance;
        _groundLayer = data.GroundLayer;

        _isGrounded = true;
        _isGroundedPreviousState = _isGrounded;
    }

    public void UpdateGroundedState()
    {
        _isGrounded = Physics2D.Raycast(_groundCheck.position,Vector3.down,
            _groundCheckDistance, _groundLayer);

        if (_isGrounded != _isGroundedPreviousState)
        {
            if(_isGrounded)
                OnJustLanded?.Invoke();

            _isGroundedPreviousState = _isGrounded;
        }
    }
}
