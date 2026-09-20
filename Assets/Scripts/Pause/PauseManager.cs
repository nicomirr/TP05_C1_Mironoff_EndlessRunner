using UnityEngine;
using Game.Events;

namespace Game.Pause
{
    public class PauseManager : MonoBehaviour
    {
        private bool _gamePaused;

        private void Awake()
        {
            PauseEvents.OnPauseInputPressed += TogglePauseState;
            PauseEvents.OnContinueButtonClicked += TogglePauseState;
        }
             
        private void OnDestroy()
        {
            PauseEvents.OnPauseInputPressed -= TogglePauseState;
            PauseEvents.OnContinueButtonClicked -= TogglePauseState;
        }

        private void TogglePauseState()
        {           
            _gamePaused = !_gamePaused;

            UIEvents.RaiseChangeCursorVisibilityRequest(_gamePaused);

            Time.timeScale = _gamePaused ? 0f : 1f;

            if (_gamePaused)
                PauseEvents.RaiseGamePausedByInput();
            else
                PauseEvents.RaiseGameUnpausedByInput();
        }
    }
}

