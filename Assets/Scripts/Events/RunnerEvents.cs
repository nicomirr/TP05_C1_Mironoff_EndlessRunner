using System;

namespace Game.Events
{
    public static class RunnerEvents
    {
        public static event Action OnBaseSpeedRequested;
        public static event Action OnWorldSpeedRequested;
        public static event Action<float> OnBaseSpeedBroadcast;
        public static event Action<float> OnWorldSpeedBroadcast;

        public static void RaiseBaseSpeedRequested()
        {
            OnBaseSpeedRequested?.Invoke();
        }

        public static void RaiseWorldSpeedRequested()
        {
            OnWorldSpeedRequested?.Invoke();
        }

        public static void RaiseBaseSpeedBroadcast(float speed)
        {
            OnBaseSpeedBroadcast?.Invoke(speed);
        }

        public static void RaiseWorldSpeedBroadcast(float speed)
        {
            OnWorldSpeedBroadcast?.Invoke(speed);
        }
    }
}

