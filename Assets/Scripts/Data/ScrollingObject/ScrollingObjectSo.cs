using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScrollingObjectSo", menuName = "Scriptable Objects/ScrollingObjectSo")]
    public class ScrollingObjectSo : ScriptableObject
    {        

        [SerializeField] private SpeedModifierDataSo _speedModifierData;
        public SpeedModifierDataSo SpeedModifierData => _speedModifierData;

    }
}


