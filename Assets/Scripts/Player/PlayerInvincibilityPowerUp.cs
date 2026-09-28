using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Core;
using Game.VisualEffects;

namespace Game.Player
{
    public class PlayerInvincibilityPowerUp : PowerUp
    {          
        public PlayerInvincibilityPowerUp(ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger,  
            SpriteFlicker spriteFlicker, SpriteRenderer spriteRenderer, PowDataSo data)
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
            _spriteRenderer.color = _data.FlickerColor;

            yield return new WaitForSeconds( _data.Time - _data.WarningTime);

            yield return _spriteFlicker.FlickerRoutine(_data.WarningTime, _data.TotalBlinks, _data.FlickerColor);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar invencibilidad");

            RaisePowerUpFinalized();
        }               
        
    }

}

