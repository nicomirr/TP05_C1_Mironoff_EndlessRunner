using System;

namespace Game.Events
{
    public static class PlayerEvents
    {
        public static event Action OnPlayerDeath;

        public static event Action OnPowerUpEnabled;
        public static event Action OnPowerUpDisabled;

        public static void RaisePlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }

        public static void RaisePowerUpEnabled()
        {
            OnPowerUpEnabled?.Invoke();
        }

        public static void RaisePowerUpDisabled()
        {
            OnPowerUpDisabled?.Invoke();
        }
    }
}
