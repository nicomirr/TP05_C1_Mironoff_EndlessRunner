using Game.Core;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PowerUpEnablerDataSo", menuName = "Scriptable Objects/PowerUpEnablerDataSo")]
    public class PowerUpEnablerDataSo : ScriptableObject
    {
        [SerializeField] private PowerUpType _powerUpType;
        public PowerUpType PowerUpType => _powerUpType;
    }
}


