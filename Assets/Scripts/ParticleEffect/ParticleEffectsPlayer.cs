using UnityEngine;
using Game.Core;
using System.Collections.Generic;

namespace Game.ParticleEffects
{
    public class ParticleEffectsPlayer
    {
        private Dictionary<ParticleEffectType, ParticleSystem> _particleEffects;

        public ParticleEffectsPlayer(List<ParticleEffect> particleEffects)
        {
            _particleEffects = new Dictionary<ParticleEffectType, ParticleSystem>();

            foreach (var effect in particleEffects)
            {
                _particleEffects.Add(effect.ParticleEffectType, effect.ParticleSystem);
            }
        }

        public void PlayEffect(ParticleEffectType type)
        {
            _particleEffects[type].Play();
        }

    }        
}


