using System;
using Game.Data;

public static class PowerUpEvents
{
    public static event Action<PowerUpEnablerDataSo> OnPowerUpAquired;

    public static void RaisePowerUpAquired(PowerUpEnablerDataSo powerUpData)
    {
        OnPowerUpAquired?.Invoke(powerUpData);
    }
}
