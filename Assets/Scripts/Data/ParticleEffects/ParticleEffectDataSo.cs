using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParticleEffectDataSo", menuName = "Scriptable Objects/ParticleEffectDataSo")]
    public class ParticleEffectDataSo : ScriptableObject
    {
        [SerializeField] private ParticleEffectType _particleEffectType;
        public ParticleEffectType ParticleEffectType => _particleEffectType;
    }
}


