using Game.Core;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "BiomeAudioDataSo", menuName = "Scriptable Objects/BiomeAudioDataSo")]
    public class BiomeAudioDataSo : ScriptableObject
    {
        [SerializeField] private BiomeType _biomeType;
        public BiomeType BiomeType => _biomeType;

        [SerializeField] private AudioClip _musicClip;
        public AudioClip MusicClip => _musicClip;
    }
}
