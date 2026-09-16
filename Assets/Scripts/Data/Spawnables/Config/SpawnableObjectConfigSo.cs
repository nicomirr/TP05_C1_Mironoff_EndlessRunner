using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnableObjectConfigSo", menuName = "Scriptable Objects/SpawnableObjectConfigSo")]
    public class SpawnableObjectConfigSo : ScriptableObject
    {
        [SerializeField] private SpeedModifierConfigSo _speedModifierData;
        public SpeedModifierConfigSo SpeedModifierData => _speedModifierData;
    }
}

