using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    public class PlayerInvincibilityPowerUp : PowerUp
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly SpriteFlicker _spriteFlicker;

        private readonly InvincibilityPowDataSo _data;

        public PlayerInvincibilityPowerUp(ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger, InvincibilityPowDataSo data, SpriteFlicker spriteFlicker, 
            SpriteRenderer spriteRenderer)
        {
            _coroutineRunner = coroutineRunner;
            _playerStateChanger = stateChanger;

            _data = data;

            _spriteFlicker = spriteFlicker;
            _spriteRenderer = spriteRenderer;
        }

        public override bool TryEnablePowerUp()
        {           
            if (!_playerStateChanger.TryChangeState(PlayerState.Invincible)) return false;

            _coroutineRunner.RunCoroutine(InvincibilityRoutine());

            return true;
        }

        public IEnumerator InvincibilityRoutine()
        {            
            _spriteRenderer.color = _data.InvincibilityColor;

            yield return new WaitForSeconds( _data.Time - _data.WarningTime);

            yield return _spriteFlicker.FlickerRoutine(_data.WarningTime, _data.TotalWarningBlinks, _data.InvincibilityColor);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar invencibilidad");

            RaisePowerUpFinalized();
        }               
        
    }

}

