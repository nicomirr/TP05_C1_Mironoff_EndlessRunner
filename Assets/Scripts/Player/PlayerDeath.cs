using UnityEngine;
using Game.Data;

namespace Game.Player
{
    public class PlayerDeath
    {
        private readonly Transform _spawnPoint;
        private readonly GameObject _skullPrefab;

        public PlayerDeath(Transform spawnPoint, PlayerConfigSo _data)
        {
            _spawnPoint = spawnPoint;
            _skullPrefab = _data.SkullPrefab;
        }

        public void SpawnSkull()
        {
            Object.Instantiate(_skullPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }

}
