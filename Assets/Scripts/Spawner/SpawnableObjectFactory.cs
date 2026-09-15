using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Core;

namespace Game.Spawner
{
    public class SpawnableObjectFactory : MonoBehaviour
    {
        [SerializeField] private List<SpawnableObjectSo> _spawnableObjects = new List<SpawnableObjectSo>();
        private Dictionary<SpawnableObjectType, SpawnableObjectSo> _spawnableObjectsDictionary;

        public int Count => _spawnableObjects.Count;

        public void Initialize()
        {
            _spawnableObjectsDictionary = new Dictionary<SpawnableObjectType, SpawnableObjectSo>();

            foreach (var obstacle in _spawnableObjects)
            {
                _spawnableObjectsDictionary.Add(obstacle.Type, obstacle);
            }
        }

        public SpawnableObjectSo GetSpawnableObjectData(int index)
        {
            return _spawnableObjects[index];
        }

        public GameObject CreateSpawnableObject(SpawnableObjectType spawnableObjectType)
        {
            return Instantiate(_spawnableObjectsDictionary[spawnableObjectType].Prefab);
        }
    }
}

