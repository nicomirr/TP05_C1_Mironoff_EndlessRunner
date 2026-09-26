using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PowerUpEnablerDataSo", menuName = "Scriptable Objects/PowerUpEnablerDataSo")]
    public class PowerUpEnablerDataSo : ScriptableObject
    {
        [SerializeField] private PowerUpType _powerUpType;
        public PowerUpType PowerUpType => _powerUpType;

        [SerializeField] private AudioCategory _powerUpSfx;
        public AudioCategory PowerUpSfx => _powerUpSfx;

        [SerializeField] private string _animationTrigger;

        public int AnimationTriggerHash => Animator.StringToHash(_animationTrigger);

    }
}


