using System;

namespace Game.Events
{
    public static class UIEvents
    {
        public static event Action<bool> OnChangeCursorVisibilityRequest;

        public static event Action OnSettingsClicked;
        public static event Action OnCreditsClicked;
        public static event Action OnBackClicked;
                
        public static void RaiseChangeCursorVisibilityRequest(bool isVisible)
        {
            OnChangeCursorVisibilityRequest?.Invoke(isVisible);
        }

        public static void RaiseSettingsClicked()
        {
            OnSettingsClicked?.Invoke();
        }

        public static void RaiseCreditsClicked()
        {
            OnCreditsClicked?.Invoke();
        }

        public static void RaiseBackClicked()
        {
            OnBackClicked?.Invoke();
        }
                
    }
}

