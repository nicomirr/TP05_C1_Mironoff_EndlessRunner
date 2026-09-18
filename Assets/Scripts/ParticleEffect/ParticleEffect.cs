using UnityEngine;
using Game.Data;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private ParticleEffectDataSo _data;

        private ParticleSystem _particleSystem;

        public ParticleSystem ParticleSystem => _particleSystem;

        private ParticleEffectType _particleEffectType;
        public ParticleEffectType ParticleEffectType => _particleEffectType;

        private void Awake()
        {
            _particleEffectType = _data.ParticleEffectType;
            _particleSystem = GetComponent<ParticleSystem>();
        }
        
    }
}

