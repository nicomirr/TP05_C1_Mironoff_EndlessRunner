using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SpawnableObject", menuName = "Scriptable Objects/SpawnableObject")]
    public class SpawnableObjectSo : ScriptableObject
    {
        [SerializeField] private SpawnableObjectCategory _category;
        public SpawnableObjectCategory Category => _category;

        [SerializeField] private SpawnableObjectType _type;
        public SpawnableObjectType Type => _type;

        [SerializeField] private GameObject _prefab;
        public GameObject Prefab => _prefab;
    }
}


