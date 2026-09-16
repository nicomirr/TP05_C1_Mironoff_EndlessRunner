using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpeedModifierConfig", menuName = "Scriptable Objects/SpeedModifierConfig")]
    public class SpeedModifierConfigSo : ScriptableObject
    {
        [Range(0.1f, 1f)][SerializeField] private float _speedModifier;
        public float SpeedModifier => _speedModifier;
    }
}


