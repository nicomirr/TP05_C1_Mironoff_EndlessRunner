using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SineMovementDataSo", menuName = "Scriptable Objects/SineMovementDataSo")]
    public class SineMovementDataSo : ScriptableObject
    {
        [Range(0.25f, 1f)][SerializeField] private float _amplitude;
        public float Amplitude => _amplitude;

        [Range(0.5f, 1.25f)][SerializeField] private float _frequency;
        public float Frequency => _frequency;
    }

}
