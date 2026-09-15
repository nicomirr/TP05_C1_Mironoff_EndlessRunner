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
                        
        private Coroutine _spawnCoroutine;

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
            if (_spawnCoroutine != null) return;

            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            SpawnableObjectCategory[] categories = (SpawnableObjectCategory[])System.Enum.GetValues(typeof(SpawnableObjectCategory));

            while (true)
            {
                float spawnTime = Random.Range(_data.MinSpawnTime, _data.MaxSpawnTime);

                yield return new WaitForSeconds(spawnTime);
                
                SpawnableObjectCategory randomCategory = categories[Random.Range(0, categories.Length)];
                                
                SpawnableObjectSpawner currentSpawner = null;

                GameObject spawnableObject = null;

                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    spawnableObject = spawner.TrySpawnObject(randomCategory);

                    if (spawnableObject != null)
                    {
                        currentSpawner = spawner;
                        break;
                    }
                }
            }
        }
        
    }
}

