using UnityEngine;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.ParticleEffects;

namespace Game.Player
{
    public class PlayerJump
    {
        private readonly Rigidbody2D _rb;
        private readonly float _jumpForce;

        private readonly ParticleEffectsPlayer _particleEffectsPlayer;
        private readonly AudioPlayer _audioPlayer;

        public PlayerJump(Rigidbody2D rb, PlayerConfigSo data, ParticleEffectsPlayer particleEffectsPlayer,
            AudioPlayer audioPlayer)
        {
            _rb = rb;
            _jumpForce = data.JumpForce;

            _particleEffectsPlayer = particleEffectsPlayer;
            _audioPlayer = audioPlayer;
        }

        public void Jump()
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _particleEffectsPlayer.PlayEffect(ParticleEffectType.Jump);
            _audioPlayer.PlayAudio(AudioCategory.JumpSFX);
        }

        public void HandleLand()
        {
            _audioPlayer.PlayAudio(AudioCategory.LandSFX);
            _particleEffectsPlayer.PlayEffect(ParticleEffectType.Land);
        }
    }
}

