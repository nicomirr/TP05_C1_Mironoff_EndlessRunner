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

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IPlayerStateChanger _playerStateChanger;

        private readonly float _invincibilityTime;
        private readonly float _finishInvincibilityWarningTime;
        private readonly int _totalWarningBlinks;
        private readonly Color32 _invincibilityColor;

        public PlayerInvincibilityPowerUp(InvincibilityPowDataSo data, SpriteFlicker spriteFlicker, SpriteRenderer spriteRenderer, ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger)
        {
            _invincibilityTime = data.Time;
            _finishInvincibilityWarningTime = data.WarningTime;
            _totalWarningBlinks = data.TotalWarningBlinks;
            _invincibilityColor = data.InvincibilityColor;

            _coroutineRunner = coroutineRunner;
            _playerStateChanger = stateChanger;

            _spriteFlicker = spriteFlicker;
            _spriteRenderer = spriteRenderer;
        }

        public override bool TryEnablePowerUp()
        {
            bool stateChanged = _playerStateChanger.TryChangeState(PlayerState.Invincible);

            if (!stateChanged) return false;

            _coroutineRunner.RunCoroutine(InvincibilityTimerRoutine());

            return true;
        }

        public IEnumerator InvincibilityTimerRoutine()
        {            
            _spriteRenderer.color = _invincibilityColor;

            yield return new WaitForSeconds(_invincibilityTime - _finishInvincibilityWarningTime);

            yield return _spriteFlicker.FlickerRoutine(_finishInvincibilityWarningTime, _totalWarningBlinks, _invincibilityColor);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar invencibilidad");

            RaisePowerUpFinalized();
        }               
        
    }

}

