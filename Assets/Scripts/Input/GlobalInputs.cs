using UnityEngine;
using UnityEngine.InputSystem;
using Game.Events;

namespace Game.Inputs
{
    public class GlobalInputs : MonoBehaviour
    {
        private GameControls _globalControls;
     
        private InputAction _pauseInput;

        private void Awake()
        {
            _globalControls = new GameControls();

            _pauseInput = _globalControls.Global.Pause;
        }

        private void OnEnable()
        {
            _globalControls.Global.Enable();

            _pauseInput.performed += OnPausePressed;
            PauseEvents.OnPauseInputDisableRequest += DisableGlobalInputs;
            PlayerEvents.OnPlayerDeath += DisableGlobalInputs;
        }

        private void OnDisable()
        {
            _pauseInput.performed -= OnPausePressed;
            PauseEvents.OnPauseInputDisableRequest -= DisableGlobalInputs;
            PlayerEvents.OnPlayerDeath -= DisableGlobalInputs;

            _globalControls.Global.Disable();
        }

        private void OnPausePressed(InputAction.CallbackContext ctx)
        {
            PauseEvents.RaisePauseInputPressed();
        }

        private void DisableGlobalInputs()
        {            
            this.gameObject.SetActive(false);
        }
    }

}

