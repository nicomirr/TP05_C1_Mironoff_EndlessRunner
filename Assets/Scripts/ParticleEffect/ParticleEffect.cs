using UnityEngine;
using Game.Data;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private ParticleEffectDataSo _data;
        public ParticleSystem ParticleSystem => GetComponent<ParticleSystem>();
        public ParticleEffectType ParticleEffectType => _data.ParticleEffectType;    
    }
}

