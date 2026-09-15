using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ObjectPoolConfigSo", menuName = "Scriptable Objects/ObjectPoolConfigSo")]
    public class ObjectPoolConfigSo : ScriptableObject
    {
        [SerializeField] private int _similarObjectAmount;
        public int SimilarObjectAmount => _similarObjectAmount;
    }
}


