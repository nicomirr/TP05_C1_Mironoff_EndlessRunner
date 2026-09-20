using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpeedModifierDataSo", menuName = "Scriptable Objects/SpeedModifierDataSo")]
    public class SpeedModifierDataSo : ScriptableObject
    {
        [SerializeField] private SpeedType _speedType;
        public SpeedType SpeedType => _speedType;

        [Range(0.1f, 1.5f)][SerializeField] private float _speedModifier;
        public float SpeedModifier => _speedModifier;
    }
}


