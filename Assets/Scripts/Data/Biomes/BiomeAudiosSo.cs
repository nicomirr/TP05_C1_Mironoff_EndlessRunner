using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomeAudiosSo", menuName = "Scriptable Objects/BiomeAudiosSo")]
    public class BiomeAudiosSo : ScriptableObject
    {
        [SerializeField] private List<BiomeAudioDataSo> _biomeAudios;
        public List<BiomeAudioDataSo> BiomeAudios => _biomeAudios;
    }

}

