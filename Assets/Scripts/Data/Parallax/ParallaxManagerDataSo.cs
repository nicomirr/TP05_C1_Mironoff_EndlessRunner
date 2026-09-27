using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxManagerDataSo", menuName = "Scriptable Objects/ParallaxManagerDataSo")]
    public class ParallaxManagerDataSo : ScriptableObject
    {
        [SerializeField] private ParallaxBiomesConfigSo _biomesConfig;
        public ParallaxBiomesConfigSo BiomesConfig => _biomesConfig;

    }
}
