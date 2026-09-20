using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "SliderTypeSo", menuName = "Scriptable Objects/SliderTypeSo")]
    public class SliderTypeSo : ScriptableObject
    {
        [SerializeField] private List<string> _volumeTypes;
        public List<string> VolumeTypes => _volumeTypes;
    }

}

