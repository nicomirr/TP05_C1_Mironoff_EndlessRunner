using System.Collections.Generic;
using Game.Core;
using Game.Events;
using Game.Audio;

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

        //ver como poner para cada Pow un audio y un efecto
        public void AddPowerUp(PowerUpType powerUpType, PowerUp powerUp)
        {
            _powerUps[powerUpType] = powerUp;
            powerUp.OnPowerUpFinalized += HandlePowerUpFinalized;
        }

        public void TryEnablePowerUp(PowerUpType powerUpType)
        {
            bool powerUpEnabled = _powerUps[powerUpType].TryEnablePowerUp();

            if (!powerUpEnabled) return;

            HandlePowerUpEnablement();
        }

        private void HandlePowerUpEnablement()
        {
            PlayerEvents.RaisePowerUpEnabled();
            _audioPlayer.PlayAudio(AudioCategory.PowUpEnabledSFX);
            _powerUpEffect.PlayPowerUpEffect();
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

