using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpeedModifierConfig", menuName = "Scriptable Objects/SpeedModifierConfig")]
    public class SpeedModifierConfigSo : ScriptableObject
    {
        [SerializeField] private SpeedType _speedType;
        public SpeedType SpeedType => _speedType;

        [Range(0.1f, 1.5f)][SerializeField] private float _speedModifier;
        public float SpeedModifier => _speedModifier;
    }
}


