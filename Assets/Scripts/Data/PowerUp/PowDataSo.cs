using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PowDataSo", menuName = "Scriptable Objects/PowDataSo")]
    public class PowDataSo : ScriptableObject
    {
        [SerializeField] protected float _time;
        public float Time => _time;
    }

}

