using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScrollingObjectSo", menuName = "Scriptable Objects/ScrollingObjectSo")]
    public class ScrollingObjectSo : ScriptableObject
    {

        [SerializeField] private float _speed;
        public float Speed => _speed;

    }
}


