using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs
    {
        public bool JumpPressed => _jumpAction.WasPressedThisFrame();
        public bool PausePressed => _pauseInput.WasPressedThisFrame();

        private readonly GameControls _playerControls;

        private InputAction _jumpAction;
        private InputAction _pauseInput;

        public PlayerInputs()
        {
            _playerControls = new GameControls();
            EnablePlayerInputs();
        }

        private void EnablePlayerInputs()
        {
            _jumpAction = _playerControls.Player.Jump;
            _pauseInput = _playerControls.Player.Pause;

            _jumpAction.Enable();
            _pauseInput.Enable();
        }

        public void Deinitialize()
        {
            _playerControls.Disable();
            _playerControls.Dispose();
        }

    }
}

