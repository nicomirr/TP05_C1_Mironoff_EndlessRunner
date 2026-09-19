using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScalableObjectConfigSo", menuName = "Scriptable Objects/ScalableObjectConfigSo")]
    public class ScalableObjectConfigSo : ScriptableObject
    {
        [SerializeField] private float _scaleMultiplier;
        public float ScaleMultiplier => _scaleMultiplier;

        [SerializeField] private float _scaleTime;
        public float ScaleTime => _scaleTime;
    }

}

