using System;

namespace Game.Events
{
    public static class ScreenTransitionEvents
    {
        public static event Action OnRequestFadeIn;
        public static event Action OnRequestFadeOut;

        public static void RaiseRequestFadeIn()
        {
            OnRequestFadeIn?.Invoke();
        }

        public static void RaiseRequestFadeOut()
        {
            OnRequestFadeOut?.Invoke();
        }
    }
}

