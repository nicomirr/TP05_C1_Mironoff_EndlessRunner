using Game.Core;
using System;

namespace Game.Events
{
    public static class PlayerEvents
    {
        public static event Action OnPlayerHealed;
        public static event Action OnPlayerDamaged;
        public static event Action OnPlayerDeath;

        public static event Action OnPowerUpEnabled;
        public static event Action OnPowerUpDisabled;

        public static void RaisePlayerHealed()
        {
            OnPlayerHealed?.Invoke();
        }

        public static void RaisePlayerDamaged()
        {
            OnPlayerDamaged?.Invoke();
        }

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
