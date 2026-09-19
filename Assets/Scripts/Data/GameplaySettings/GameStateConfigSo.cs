using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "GameStateConfigSo", menuName = "Scriptable Objects/GameStateConfigSo")]
    public class GameStateConfigSo : ScriptableObject
    {
        [Tooltip("La distancia entre obstáculos durante el juego cambia dependiendo de este valor inicial")]
        [SerializeField] private float _initialWorldSpeed;
        public float InitialWorldSpeed => _initialWorldSpeed;

        [SerializeField] private float _maxWorldSpeed;
        public float MaxWorldSpeed => _maxWorldSpeed;

        [SerializeField] private float _slowedDownWorldSpeed;
        public float SlowedDownWorldSpeed => _slowedDownWorldSpeed;
        
        [SerializeField] private float _speedProgression;
        public float SpeedProgression => _speedProgression;

        [SerializeField] private float _speedProgressionTime;
        public float SpeedProgressionTime => _speedProgressionTime;

    }

}
