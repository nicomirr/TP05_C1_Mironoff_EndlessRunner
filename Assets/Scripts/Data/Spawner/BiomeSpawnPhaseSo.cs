using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomeSpawnPhase", menuName = "Scriptable Objects/BiomeSpawnPhase")]
    public class BiomeSpawnPhaseSo : ScriptableObject
    {
        [SerializeField] private BiomeType _biomeType;
        public BiomeType BiomeType => _biomeType;

        [SerializeField] private List<SpawnPhaseSo> _phases;
        public List<SpawnPhaseSo> Phases => _phases;
    }
}

