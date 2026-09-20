using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxDataSo", menuName = "Scriptable Objects/ParallaxDataSo")]
    public class ParallaxDataSo : ScriptableObject
    {
        [SerializeField] private SpeedModifierDataSo _speedModifierData;
        public SpeedModifierDataSo SpeedModifierData => _speedModifierData;

        [Tooltip("Controla el último valor de X antes de que se reinicie la posición del background")]
        [SerializeField] private float _minXPos;
        public float MinXPos => _minXPos;

    }
}


