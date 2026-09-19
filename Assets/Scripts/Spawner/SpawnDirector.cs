using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Core;
using Game.Data;
using Game.Events;

namespace Game.Spawner
{
    public class SpawnDirector : MonoBehaviour
    {
        [SerializeField] private SpawnerConfigSo _data;
        [SerializeField] private List<SpawnableObjectSpawner> _spawners = new List<SpawnableObjectSpawner>();
        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;

        private ISpeedProvider _worldSpeedProvider;
        private Coroutine _spawnCoroutine;

        private SpawnProgressionSo _spawnProgression;
        
        private int _currentPhaseIndex;

        private float _speedPerPhase;
        private bool _finalPhaseReached;

        private bool _playerPoweredUp;

        private void Awake()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;
            _spawnProgression = _data.SpawnProgression;
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopObjectSpawners;

            PlayerEvents.OnPowerUpEnabled += HandlePlayerPowerUpEnabled;
            PlayerEvents.OnPowerUpDisabled += HandlePlayerPowerUpDisabled;
        }

        private void Start()
        {
            _currentPhaseIndex = 0;

            _speedPerPhase = (_worldSpeedProvider.WorldMaxSpeed - _worldSpeedProvider.WorldBaseSpeed) / _spawnProgression.SpawnPhases.Count;

            StartObjectSpawners();
        }

        private void Update()
        {
            UpdatePhaseIndex();
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopObjectSpawners;

            PlayerEvents.OnPowerUpEnabled -= HandlePlayerPowerUpEnabled;
            PlayerEvents.OnPowerUpDisabled -= HandlePlayerPowerUpDisabled;
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
               

        private void UpdatePhaseIndex()
        {
            if (_finalPhaseReached) return;

            float speedProgress = _worldSpeedProvider.WorldCurrentSpeed - _worldSpeedProvider.WorldBaseSpeed;

            int newPhaseIndex = Mathf.FloorToInt(speedProgress / _speedPerPhase);

            newPhaseIndex = Mathf.Min(newPhaseIndex, _spawnProgression.SpawnPhases.Count - 1);

            if (newPhaseIndex != _currentPhaseIndex)
            {
                _currentPhaseIndex = newPhaseIndex;

                if (_currentPhaseIndex == _spawnProgression.SpawnPhases.Count - 1)
                    _finalPhaseReached = true;
            }
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            while (true)
            {
                int integerSpawnTime = Random.Range(_data.MinSpawnTime, _data.MaxSpawnTime + 1);
                float spawnTime = integerSpawnTime * 0.1f;

                float finalSpawnTime = spawnTime * (_worldSpeedProvider.WorldBaseSpeed / _worldSpeedProvider.WorldCurrentSpeed);

                yield return new WaitForSeconds(finalSpawnTime);

                List<SpawnableObjectCategory> availableCategories = _spawnProgression.SpawnPhases[_currentPhaseIndex].AvailableCategories;
                List<SpawnableObjectType> availableTypes = _spawnProgression.SpawnPhases[_currentPhaseIndex].AvailableTypes;

                SpawnableObjectCategory randomCategory = GetRandomCategory(availableCategories);

                
                foreach (SpawnableObjectSpawner spawner in _spawners)
                {
                    GameObject spawnableObject = spawner.TrySpawnObject(randomCategory, availableTypes);
                                        
                    if (spawnableObject != null)                                            
                        break;                    
                }
            }
        }

        private SpawnableObjectCategory GetRandomCategory(List<SpawnableObjectCategory> categories)
        {
            int acummulatedWeight = 0;

            foreach (SpawnCategoryWeight data in _data.CategoriesWeight)
            {
                if (!categories.Contains(data.Category))
                    continue;

                if (_playerPoweredUp && data.Family == SpawnableObjectFamily.PowerUp)
                    continue;

                acummulatedWeight += data.Weight;
            }

            int randomValue = Random.Range(0, acummulatedWeight);
            acummulatedWeight = 0;

            foreach (SpawnCategoryWeight data in _data.CategoriesWeight)
            {
                if (!categories.Contains(data.Category))
                    continue;

                if (_playerPoweredUp && data.Family == SpawnableObjectFamily.PowerUp)
                    continue;

                acummulatedWeight += data.Weight;

                if (randomValue < acummulatedWeight)
                    return data.Category;
            }

            return SpawnableObjectCategory.GroundObstacle;
        }

        private void HandlePlayerPowerUpEnabled()
        {
            _playerPoweredUp = true;
        }

        private void HandlePlayerPowerUpDisabled()
        {
            _playerPoweredUp = false;
        }

    }
}

