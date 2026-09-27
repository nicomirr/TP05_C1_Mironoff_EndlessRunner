using Game.Core;
using System;

namespace Game.Events
{
    public static class GameStateEvents
    {
        public static event Action OnWorldSpeedRequested;
        public static event Action<float> OnWorldSpeedBroadcast;

        public static event Action OnStopSpawners;

        public static event Action<BiomeType> OnBiomeTypeBroadcast;

        public static event Action OnPauseInputEnableRequest;

        public static event Action OnPauseInputDisableRequest;

        public static void RaiseWorldSpeedRequested()
        {
            OnWorldSpeedRequested?.Invoke();
        }

        public static void RaiseWorldSpeedBroadcast(float speed)
        {
            OnWorldSpeedBroadcast?.Invoke(speed);
        }
                
        public static void RaiseStopSpawners()
        {
            OnStopSpawners?.Invoke();
        }        

        public static void RaiseBiomeTypeBroadcast(BiomeType biomeType)
        {
            OnBiomeTypeBroadcast?.Invoke(biomeType);
        }

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

