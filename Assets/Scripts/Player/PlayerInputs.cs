using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs
    {
        public bool JumpPressed => _jumpAction.WasPressedThisFrame();

        private readonly GameControls _playerControls;

        private InputAction _jumpAction;

        public PlayerInputs()
        {
            _playerControls = new GameControls();
            EnablePlayerInputs();
            _jumpAction = _playerControls.Player.Jump;
        }

        public void EnablePlayerInputs()
        {
            _playerControls.Player.Enable();
        }

        public void DisablePlayerInputs()
        {
            _playerControls.Player.Disable();
        }

        public void Deinitialize()
        {
            _playerControls.Player.Disable();           
            _playerControls.Dispose();
        }

    }
}

