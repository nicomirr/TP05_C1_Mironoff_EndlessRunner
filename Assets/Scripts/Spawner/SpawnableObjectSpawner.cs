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

        public GameObject TrySpawnObject(SpawnableObjectCategory category, List<SpawnableObjectType> availableTypes)
        {
            if (_category != category) return null;

            Vector2 spawnPos = _positionProvider.GetSpawnPos();

            GameObject spawnableObject = _spawnableObjectPool.GetRandomSpawnableObject(_category, availableTypes);

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

