using Game.Data;
using System;
using UnityEngine;

namespace Game.Core
{
    public abstract class PowerUp
    {
        protected PowDataSo _data;

        protected ICoroutineRunner _coroutineRunner;
        protected IPlayerStateChanger _playerStateChanger;

        protected SpriteRenderer _spriteRenderer;
        protected SpriteFlicker _spriteFlicker;

        public event Action OnPowerUpFinalized;
        public abstract bool TryEnablePowerUp();

        protected void RaisePowerUpFinalized()
        {
            OnPowerUpFinalized?.Invoke();
        }
    }

}
