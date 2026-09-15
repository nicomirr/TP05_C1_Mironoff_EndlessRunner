using Game.Data;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _data;
        [SerializeField] private Transform _groundCheck;

        private PlayerInputs _playerInputs;
        private Jumper _jumper;
        private PlayerGroundCheck _playerGroundCheck;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _jumper = new Jumper(GetComponent<Rigidbody2D>(), _data);
            _playerGroundCheck = new PlayerGroundCheck(_groundCheck, _data);
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleJump();
        }

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();
        }

        private void HandleJump()
        {
            if(_playerInputs.JumpPressed && _playerGroundCheck.IsGrounded)
            {
                _jumper.Jump();
            }
        }
    }
}

