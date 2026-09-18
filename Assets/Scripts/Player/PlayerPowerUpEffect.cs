using UnityEngine;

namespace Game.Player
{
    public class PlayerPowerUpEffect
    {
        private static readonly int POWERUP_TRIGGER = Animator.StringToHash("powerUp");

        private readonly Animator _animator;

        public PlayerPowerUpEffect(Animator animator)
        {
            _animator = animator;
        }

        public void PlayPowerUpEffect()
        {
            _animator.SetTrigger(POWERUP_TRIGGER);
        }
    }
}

