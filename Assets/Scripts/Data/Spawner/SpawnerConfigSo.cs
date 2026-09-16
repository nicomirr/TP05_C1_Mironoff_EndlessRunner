using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Scriptable Objects/SpawnerConfig")]
    public class SpawnerConfigSo : ScriptableObject
    {
        [Tooltip("El valor se divide por 10")]
        [Range(7,20)][SerializeField] private int _minSpawnTime;
        public int MinSpawnTime => _minSpawnTime;

        [Tooltip("El valor se divide por 10")]
        [Range(7, 20)][SerializeField] private int _maxSpawnTime;
        public int MaxSpawnTime => _maxSpawnTime;
    }
}


