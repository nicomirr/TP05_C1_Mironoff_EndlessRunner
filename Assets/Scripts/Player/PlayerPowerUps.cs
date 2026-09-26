using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Events;
using Game.Audio;
using Game.Data;

namespace Game.Player
{
    public class PlayerPowerUps
    {       
        private readonly Dictionary<PowerUpType, PowerUp> _powerUps = new();

        private readonly AudioPlayer _audioPlayer;
        private readonly PlayerPowerUpEffect _powerUpEffect;

        public PlayerPowerUps(AudioPlayer audioPlayer, PlayerPowerUpEffect powerUpEffect)
        {
            _audioPlayer = audioPlayer;
            _powerUpEffect = powerUpEffect;
        }

        public void AddPowerUp(PowerUpType powerUpType, PowerUp powerUp)
        {
            _powerUps[powerUpType] = powerUp;
            powerUp.OnPowerUpFinalized += HandlePowerUpFinalized;
        }

        public void TryEnablePowerUp(PowerUpEnablerDataSo powerUpData)
        {
            bool powerUpEnabled = _powerUps[powerUpData.PowerUpType].TryEnablePowerUp();

            if (!powerUpEnabled) return;

            HandlePowerUpEnablement(powerUpData);
        }

        private void HandlePowerUpEnablement(PowerUpEnablerDataSo powerUpData)
        {
            PlayerEvents.RaisePowerUpEnabled();
            _audioPlayer.PlayAudio(powerUpData.PowerUpSfx);
            _powerUpEffect.PlayPowerUpEffect(powerUpData.AnimationTriggerHash);
        }

        private void HandlePowerUpFinalized()
        {
            PlayerEvents.RaisePowerUpDisabled();
        }

        public void Deinitialize()
        {
            foreach (PowerUp powerUp in _powerUps.Values)
            {
                powerUp.OnPowerUpFinalized -= HandlePowerUpFinalized;
            }
        }
    }
}

