using System;

namespace Game.Core
{
    public abstract class PowerUp
    {
        protected ICoroutineRunner _coroutineRunner;
        protected IPlayerStateChanger _playerStateChanger;

        public event Action OnPowerUpFinalized;
        public abstract bool TryEnablePowerUp();

        protected void RaisePowerUpFinalized()
        {
            OnPowerUpFinalized?.Invoke();
        }
    }

}
