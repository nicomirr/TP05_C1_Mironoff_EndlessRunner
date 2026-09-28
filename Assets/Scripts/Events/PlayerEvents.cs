using System;

namespace Game.Events
{
    public static class PlayerEvents
    {
        public static event Action<int> OnPlayerHealthInitialized;

        public static event Action OnPlayerHealed;
        public static event Action OnPlayerDamaged;
        public static event Action OnPlayerDeath;
        public static event Action<float> OnPlayerEnergyChanged;

        public static event Action OnPowerUpEnabled;
        public static event Action OnPowerUpDisabled;

        public static void RaisePlayerHealthInitialized(int health)
        {
            OnPlayerHealthInitialized?.Invoke(health);
        }

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

        public static void RaisePlayerEnergyChanged(float energy)
        {
            OnPlayerEnergyChanged?.Invoke(energy);
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
