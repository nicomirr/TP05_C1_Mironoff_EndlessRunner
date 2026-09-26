using Game.Core;
using Game.Data;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class PlayerHealPowerUp : PowerUp
    {
        private readonly PowDataSo _data;
        private readonly PlayerHealth _playerHealth;

        public PlayerHealPowerUp(ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger, PowDataSo data, PlayerHealth playeHealth)
        {
            _coroutineRunner = coroutineRunner;
            _playerStateChanger = stateChanger;

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

            yield return new WaitForSeconds(1);

            if (!_playerStateChanger.TryChangeState(PlayerState.Normal))
                Debug.LogError("ERROR. Debería poder salir a normal siempre al terminar de curarse");

            RaisePowerUpFinalized();
        }
    }
}
