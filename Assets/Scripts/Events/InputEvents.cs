using System;

namespace Game.Events
{
    public static class InputEvents
    {
        public static event Action OnPauseInputEnableRequest;

        public static event Action OnPauseInputDisableRequest;

        public static void RaisePauseInputEnableRequest()
        {
            OnPauseInputEnableRequest?.Invoke();
        }

        public static void RaisePauseInputDisableRequest()
        {
            OnPauseInputDisableRequest?.Invoke();
        }
    }

}
