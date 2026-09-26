using System;
using Game.Core;

public static class PowerUpEvents
{
    public static event Action<PowerUpType> OnPowerUpAquired;

    public static void RaisePowerUpAquired(PowerUpType powerUpType)
    {
        OnPowerUpAquired?.Invoke(powerUpType);
    }
}
