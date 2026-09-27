using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomePhaseSo", menuName = "Scriptable Objects/BiomePhaseSo")]
    public class BiomePhase : ScriptableObject
    {
        [SerializeField] private BiomeType _biomeType;
        public BiomeType BiomeType => _biomeType;

        [SerializeField] private float _changeTime;
        public float ChangeTime => _changeTime;   
    }
}

