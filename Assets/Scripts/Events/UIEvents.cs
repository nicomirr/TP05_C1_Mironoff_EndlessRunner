using System;

namespace Game.Events
{
    public static class UIEvents
    {            
        public static event Action OnSettingsClicked;
        public static event Action OnHelpClicked;
        public static event Action OnCreditsClicked;
        public static event Action OnBackClicked;                     

        public static event Action<float> OnDisplayScoreboardRequest;    
       
        public static void RaiseSettingsClicked()
        {
            OnSettingsClicked?.Invoke();
        }

        public static void RaiseHelpClicked()
        {
            OnHelpClicked?.Invoke();
        }

        public static void RaiseCreditsClicked()
        {
            OnCreditsClicked?.Invoke();
        }

        public static void RaiseBackClicked()
        {
            OnBackClicked?.Invoke();
        }

        public static void RaiseDisplayScoreboard(float score)
        {
            OnDisplayScoreboardRequest?.Invoke(score);
        }

    }
}

