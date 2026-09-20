using System;

namespace Game.Events
{
    public static class PauseEvents
    {
        public static event Action OnPauseInputPressed;    
        
        public static event Action OnGamePausedByInput;

        public static event Action OnGameUnpausedByInput;

        public static event Action OnContinueButtonClicked;

        public static event Action OnPauseInputDisableRequest;

        public static void RaisePauseInputPressed()
        {
            OnPauseInputPressed?.Invoke();
        }

        public static void RaiseGamePausedByInput()
        {
            OnGamePausedByInput?.Invoke();
        }

        public static void RaiseGameUnpausedByInput()
        {
            OnGameUnpausedByInput?.Invoke();
        }

        public static void RaiseContinueClicked()
        {
            OnContinueButtonClicked?.Invoke();
        }

        public static void RaisePauseInputDisableRequest()
        {
            OnPauseInputDisableRequest?.Invoke();
        }
    }
}


