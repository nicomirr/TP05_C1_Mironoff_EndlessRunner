using UnityEngine;

namespace Game.Player
{
    public class PlayerPowerUpEffect
    {        
        private readonly Animator _animator;

        public PlayerPowerUpEffect(Animator animator)
        {
            _animator = animator;
        }

        public void PlayPowerUpEffect(int triggerHash)
        {
            _animator.SetTrigger(triggerHash);
        }
    }
}

