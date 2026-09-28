using System;
using Game.Data;

namespace Game.Events
{
    public static class PowerUpEvents
    {
        public static event Action<PowerUpEnablerDataSo> OnPowerUpAcquired;

        public static void RaisePowerUpAcquired(PowerUpEnablerDataSo powerUpData)
        {
            OnPowerUpAcquired?.Invoke(powerUpData);
        }
    }

}
