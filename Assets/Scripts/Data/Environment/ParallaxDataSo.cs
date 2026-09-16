using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxDataSo", menuName = "Scriptable Objects/ParallaxDataSo")]
    public class ParallaxDataSo : ScriptableObject
    {
        [Tooltip("Controla el último valor de X antes de que se reinicie la posición del background")]
        [SerializeField] private float _minXPos;
        public float MinXPos => _minXPos;

        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;
    }
}


