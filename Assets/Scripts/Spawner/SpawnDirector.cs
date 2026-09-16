using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Spawner
{
    public class SpawnDirector : MonoBehaviour
    {
        [SerializeField] private SpawnerConfigSo _data;
        [SerializeField] private List<SpawnableObjectSpawner> _spawners = new List<SpawnableObjectSpawner>();
        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;

        private ISpeedProvider _worldSpeedProvider;
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;
        }

        private void Start()
        {
            StartObjectSpawners();
        }

        private void StartObjectSpawners()
        {
            if (_spawnCoroutine != null) return;

            _spawnCoroutine = StartCoroutine(SpawnObjectsRoutine());
        }

        private void StopObjectSpawners()
        {
            if (_spawnCoroutine == null) return;

            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            while (true)
            {
                int integerSpawnTime = Random.Range(_data.MinSpawnTime, _data.MaxSpawnTime + 1);
                float spawnTime = integerSpawnTime * 0.1f;

                float finalSpawnTime = spawnTime * (_worldSpeedProvider.WorldBaseSpeed / _worldSpeedProvider.WorldCurrentSpeed);

                yield return new WaitForSeconds(finalSpawnTime);

                SpawnableObjectCategory randomCategory = GetRandomCategory();                               
                
                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    GameObject spawnableObject = spawner.TrySpawnObject(randomCategory);
                                        
                    if (spawnableObject != null)                                            
                        break;                    
                }
            }
        }

        private SpawnableObjectCategory GetRandomCategory()
        {
            int acummulatedWeight = 0;

            foreach(SpawnCategoryWeight data in _data.CategoriesWeight)
            {
                acummulatedWeight += data.Weight;
            }                      

            int randomValue = Random.Range(0, acummulatedWeight);
            acummulatedWeight = 0;

            foreach (SpawnCategoryWeight data in _data.CategoriesWeight)
            {
                acummulatedWeight += data.Weight;

                if (randomValue < acummulatedWeight)
                {
                    return data.Category;
                }
            }

            return SpawnableObjectCategory.GroundObject;
                        
        }
        
    }
}

