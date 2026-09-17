using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Scriptable Objects/SpawnerConfig")]
    public class SpawnerConfigSo : ScriptableObject
    {
        [SerializeField] private SpawnProgressionSo _spawnProgression;
        public SpawnProgressionSo SpawnProgression => _spawnProgression;

        [Tooltip("Controla la probabilidad de que salga una categoria")]
        [SerializeField] private List<SpawnCategoryWeight> _categoriesWeight;
        public List<SpawnCategoryWeight> CategoriesWeight => _categoriesWeight;

        [Tooltip("El valor se divide por 10")]
        [Range(7,20)][SerializeField] private int _minSpawnTime;
        public int MinSpawnTime => _minSpawnTime;

        [Tooltip("El valor se divide por 10")]
        [Range(7, 20)][SerializeField] private int _maxSpawnTime;
        public int MaxSpawnTime => _maxSpawnTime;
                
    }
}


