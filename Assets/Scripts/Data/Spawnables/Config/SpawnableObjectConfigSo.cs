using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnableObjectConfigSo", menuName = "Scriptable Objects/SpawnableObjectConfigSo")]
    public class SpawnableObjectConfigSo : ScriptableObject
    {
        [SerializeField] private SpeedModifierDataSo _speedModifierData;
        public SpeedModifierDataSo SpeedModifierData => _speedModifierData;

    }
}

