using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "RunnerStateConfigSo", menuName = "Scriptable Objects/RunnerStateConfigSo")]
    public class RunnerStateConfigSo : ScriptableObject
    {
        [SerializeField] private float _initialWorldSpeed;
        public float InitialWorldSpeed => _initialWorldSpeed;

        [SerializeField] private float _maxWorldSpeed;
        public float MaxWorldSpeed => _maxWorldSpeed;   
        
        [SerializeField] private float _speedProgression;
        public float SpeedProgression => _speedProgression;

        [SerializeField] private float _speedProgressionTime;
        public float SpeedProgressionTime => _speedProgressionTime;

    }

}
