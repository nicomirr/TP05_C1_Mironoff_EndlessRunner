using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "HeartPrefabSo", menuName = "Scriptable Objects/HeartPrefabSo")]
    public class HeartPrefabSo : ScriptableObject
    {
        [SerializeField] private GameObject _heartPrefab;
        public GameObject HeartPrefab => _heartPrefab;
    }

}
