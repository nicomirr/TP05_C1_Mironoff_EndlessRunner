using System;

namespace Game.Events
{
    public static class PlayerEvents
    {
        public static event Action OnInvincibilityEnabled;
        public static event Action OnInvincibilityDisabled;

        public static void RaiseInvincibilityEnabled()
        {
            OnInvincibilityEnabled?.Invoke();
        }

        public static void RaiseInvincibilityDisabled()
        {
            OnInvincibilityDisabled?.Invoke();
        }
    }

}
