using UnityEngine;
using UnityEngine.InputSystem;
using Game.Events;
using System.Collections;

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
            _pauseInput.performed += OnPausePressed;
            GameStateEvents.OnPauseInputEnableRequest += EnableGlobalInputs;
            GameStateEvents.OnPauseInputDisableRequest += DisableGlobalInputs;
            PlayerEvents.OnPlayerDeath += DisableGlobalInputs;
        }

        private void Start()
        {
            StartCoroutine(EnablePauseRoutine());
        }

        private void OnDisable()
        {
            _pauseInput.performed -= OnPausePressed;
            GameStateEvents.OnPauseInputEnableRequest -= EnableGlobalInputs;
            GameStateEvents.OnPauseInputDisableRequest -= DisableGlobalInputs;
            PlayerEvents.OnPlayerDeath -= DisableGlobalInputs;

            _globalControls.Global.Disable();
        }

        private IEnumerator EnablePauseRoutine()
        {
            yield return new WaitForSeconds(0.4f);
            _globalControls.Global.Enable();
        }

        private void OnPausePressed(InputAction.CallbackContext ctx)
        {
            PauseEvents.RaisePauseInputPressed();
        }

        private void EnableGlobalInputs()
        {
            _globalControls.Global.Enable();
        }

        private void DisableGlobalInputs()
        {
            _globalControls.Global.Disable();

        }
    }

}

