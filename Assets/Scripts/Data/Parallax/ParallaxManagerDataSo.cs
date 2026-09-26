using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxManagerDataSo", menuName = "Scriptable Objects/ParallaxManagerDataSo")]
    public class ParallaxManagerDataSo : ScriptableObject
    {
        [SerializeField] private List<ParallaxDataSo> _parallaxBackgroundsData;
        public List<ParallaxDataSo> ParallaxBackgroundsData => _parallaxBackgroundsData;
    }
}
