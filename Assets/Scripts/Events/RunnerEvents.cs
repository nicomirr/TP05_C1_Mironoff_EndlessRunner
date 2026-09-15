using System;

namespace Game.Events
{
    public static class RunnerEvents
    {
        public static event Action OnWorldSpeedRequested;
        public static event Action<float> OnWorldSpeedBroadcast;

        public static void RaiseWorldSpeedRequested()
        {
            OnWorldSpeedRequested?.Invoke();
        }

        public static void RaiseWorldSpeedBroadcast(float speed)
        {
            OnWorldSpeedBroadcast?.Invoke(speed);
        }
    }
}

