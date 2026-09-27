using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections.Generic;

namespace Game.Audio
{
    public class AudioClipSwitcher : MonoBehaviour
    {
        [SerializeField] private BiomeAudiosSo _data;

        private readonly Dictionary<BiomeType, AudioClip> _biomeAudios = new();

        private AudioSource _audioSource;

        private void Awake()
        {
            foreach(BiomeAudioDataSo audioData in _data.BiomeAudios)
            {
                _biomeAudios.Add(audioData.BiomeType, audioData.MusicClip);
            }

            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameStateEvents.OnBiomeTypeBroadcast += ChangeMusic;
        }

        private void OnDisable()
        {
            GameStateEvents.OnBiomeTypeBroadcast -= ChangeMusic;
        }

        private void ChangeMusic(BiomeType biomeType)
        {
            _audioSource.Pause();
            _audioSource.clip = _biomeAudios[biomeType];
            _audioSource.Play();
        }
    }
}

