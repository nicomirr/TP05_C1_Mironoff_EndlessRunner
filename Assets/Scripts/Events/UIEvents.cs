using System;
using Game.Core;

namespace Game.Events
{
    public static class UIEvents
    {
        public static event Action OnMainMenuEntered;

        public static event Action<bool> OnChangeCursorVisibilityRequest;
        public static event Action<CursorType> OnCursorApperanceChangeRequest;

        public static event Action<int> OnInitializePlayerUIHealth;

        public static event Action<float> OnPlayerScoreUpdated;

        public static event Action<float> OnDisplayScoreboard;

        public static event Action OnSettingsClicked;
        public static event Action OnCreditsClicked;
        public static event Action OnBackClicked;
                        
        public static void RaiseMainMenuEntered()
        {
            OnMainMenuEntered?.Invoke();
        }

        public static void RaiseChangeCursorVisibilityRequest(bool isVisible)
        {
            OnChangeCursorVisibilityRequest?.Invoke(isVisible);
        }
        
        public static void RaiseCursorAppearanceChangeRequest(CursorType cursorType)
        {
            OnCursorApperanceChangeRequest?.Invoke(cursorType);
        }

        public static void RaiseInitializePlayerUIHealth(int health)
        {
            OnInitializePlayerUIHealth?.Invoke(health);
        }

        public static void RaisePlayerScoreUpdated(float score)
        {
            OnPlayerScoreUpdated?.Invoke(score);
        }

        public static void RaiseDisplayScoreboard(float score)
        {
            OnDisplayScoreboard?.Invoke(score);
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

