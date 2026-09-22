using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnCategoryWeightSo", menuName = "Scriptable Objects/SpawnCategoryWeightSo")]
    public class SpawnCategoryWeightSo : ScriptableObject
    {
        [SerializeField] private SpawnableObjectFamily _family;
        public SpawnableObjectFamily Family => _family;

        [SerializeField] private SpawnableObjectCategory _category;
        public SpawnableObjectCategory Category => _category;

        [SerializeField] private int _weight;
        public int Weight => _weight;
    }

}

