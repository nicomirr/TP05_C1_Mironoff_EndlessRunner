using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Spawner
{
    public class SpawnableObjectSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnableObjectPool _spawnableObjectPool;       
        [SerializeField] private SpawnableObjectCategory _category;

        [SerializeField] private MonoBehaviour _positionProviderMonoBehaviour;
        private ISpawnPositionProvider _positionProvider;

        private void Awake()
        {
            _positionProvider = _positionProviderMonoBehaviour as ISpawnPositionProvider;

            if (_positionProvider == null)
                Debug.LogError("Position Provider must implement ISpawnPositionProvider");
        }

        public GameObject TrySpawnObject(SpawnableObjectCategory category)
        {
            if (_category != category) return null;

            IReadOnlyList<SpawnableObjectType> availableTypes = _spawnableObjectPool.GetTypes(_category);

            Vector2 spawnPos = _positionProvider.GetSpawnPos();

            SpawnableObjectType randomType = availableTypes[Random.Range(0, availableTypes.Count)];

            GameObject spawnableObject = _spawnableObjectPool.GetRandomSpawnableObject(_category);

            if (spawnableObject == null)
            {
                Debug.LogWarning("No hay objecto disponible para spawnear");
                return null;
            }

            spawnableObject.transform.position = spawnPos;
            spawnableObject.SetActive(true);

            return spawnableObject;
        }   
                        
    }
}

