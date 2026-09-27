using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomePhasesSo", menuName = "Scriptable Objects/BiomePhasesSo")]
    public class BiomePhasesSo : ScriptableObject
    {
        [SerializeField] private List<BiomePhase> _biomes;
        public List<BiomePhase> Biomes => _biomes;
    }

}

