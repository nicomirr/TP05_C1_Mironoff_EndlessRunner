using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxDataSo", menuName = "Scriptable Objects/ParallaxDataSo")]
    public class ParallaxDataSo : ScriptableObject
    {
        [Tooltip("Controla el último valor de X antes de que se reinicie la posición del background")]
        [SerializeField] private float _minXPos;
        public float MinXPos => _minXPos;

        [Range(0.1f, 1f)][SerializeField] private float _speedModifier;
        public float SpeedModifier => _speedModifier;
    }
}


