using System;
using Game.Core;

namespace Game.Events
{
    public static class WorldEvents
    {
        public static event Action OnWorldSpeedRequested;

        public static event Action<float> OnWorldSpeedBroadcast;

        public static event Action<BiomeType> OnBiomeTypeBroadcast;

        public static void RaiseWorldSpeedRequested()
        {
            OnWorldSpeedRequested?.Invoke();
        }

        public static void RaiseWorldSpeedBroadcast(float speed)
        {
            OnWorldSpeedBroadcast?.Invoke(speed);
        }

        public static void RaiseBiomeTypeBroadcast(BiomeType biomeType)
        {
            OnBiomeTypeBroadcast?.Invoke(biomeType);
        }
    }
}

