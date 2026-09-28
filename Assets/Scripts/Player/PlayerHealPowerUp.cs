using UnityEngine;
using System.Collections;
using Game.Core;
using Game.Data;
using Game.VisualEffects;

namespace Game.Player
{
    public class PlayerHealPowerUp : PowerUp
    {        
        private readonly PlayerHealth _playerHealth;

        public PlayerHealPowerUp(ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger,
            SpriteFlicker spriteFlicker, SpriteRenderer spriteRenderer, PowDataSo data, PlayerHealth playeHealth)
        {
            _coroutineRunner = coroutineRunner;
            _playerStateChanger = stateChanger;

            _spriteFlicker = spriteFlicker;
            _spriteRenderer = spriteRenderer;

            _data = data;
            _playerHealth = playeHealth;           

        }

        public override bool TryEnablePowerUp()
        {
            if (!_playerStateChanger.TryChangeState(PlayerState.Healing)) return false;

            _coroutineRunner.RunCoroutine(HealingRoutine());

            return true;

        }

        public IEnumerator HealingRoutine()
        {            
           _playerHealth.AddHealth();

            yield return _spriteFlicker.FlickerRoutine(_data.Time, _data.TotalBlinks, _data.FlickerColor);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar de curarse");

            RaisePowerUpFinalized();
        }
    }
}
