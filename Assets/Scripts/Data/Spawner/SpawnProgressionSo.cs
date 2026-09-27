using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnProgressionSo", menuName = "Scriptable Objects/SpawnProgressionSo")]
    public class SpawnProgressionSo : ScriptableObject
    {
        [SerializeField] private List<BiomeSpawnPhaseSo> _biomePhases;
        public List<BiomeSpawnPhaseSo> BiomePhases => _biomePhases;

    }

}

