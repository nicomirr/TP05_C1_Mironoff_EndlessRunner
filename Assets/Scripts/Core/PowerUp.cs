using System;

namespace Game.Core
{
    public abstract class PowerUp
    {
        public event Action OnPowerUpFinalized;
        public abstract bool TryEnablePowerUp();

        protected void RaisePowerUpFinalized()
        {
            OnPowerUpFinalized?.Invoke();
        }
    }

}
