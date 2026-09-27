using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomesConfigSo", menuName = "Scriptable Objects/BiomesConfigSo")]
    public class ParallaxBiomesConfigSo : ScriptableObject
    {
        [SerializeField] private List<ParallaxBiomeDataSo> _biomes;
        public List<ParallaxBiomeDataSo> Biomes => _biomes;
    }

}
