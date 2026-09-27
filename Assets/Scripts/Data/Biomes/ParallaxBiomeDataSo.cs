using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomeDataSo", menuName = "Scriptable Objects/BiomeDataSo")]
    public class ParallaxBiomeDataSo : ScriptableObject
    {
        [SerializeField] private BiomeType _biomeType;
        public BiomeType BiomeType => _biomeType;

        [SerializeField] private List<ParallaxDataSo> _parallaxBackgroundsData;
        public List<ParallaxDataSo> ParallaxBackgroundsData => _parallaxBackgroundsData;

        [SerializeField] private Color32 _backgroundColor;
        public Color32 BackgroundColor => _backgroundColor;
    }

}

