using UnityEngine;
using Game.Audio;
using Game.Core;
using Game.ParticleEffects;

namespace Game.Player
{
    public class PlayerObstacleHandler
    {
        private readonly IPlayerStateReader _stateReader;
        private readonly PlayerDamageHandler _damageHandler;
        private readonly AudioPlayer _audioPlayer;
        private readonly ParticleEffectsPlayer _particleEffectsPlayer;

        public PlayerObstacleHandler(IPlayerStateReader stateReader, PlayerDamageHandler damageHandler, AudioPlayer audioPlayer, ParticleEffectsPlayer particleEffectsPlayer)
        {
            _stateReader = stateReader;
            _damageHandler = damageHandler;
            _audioPlayer = audioPlayer;
            _particleEffectsPlayer = particleEffectsPlayer;
        }

        public void HandleCollision(GameObject obstacle)
        {
            if (_stateReader.CurrentState == PlayerState.Invincible)
            {
                DestroyObstacle(obstacle);
                return;
            }

            _damageHandler.TryDamage();
        }

        private void DestroyObstacle(GameObject obstacle)
        {
            _audioPlayer.PlayAudio(AudioCategory.PuffDestroySFX);
            _particleEffectsPlayer.PlayEffect(ParticleEffectType.Destroyed);

            obstacle.SetActive(false);
        }
    }

}
