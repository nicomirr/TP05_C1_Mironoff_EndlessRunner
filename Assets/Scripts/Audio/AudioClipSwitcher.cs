using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections.Generic;

namespace Game.Audio
{
    public class AudioClipSwitcher : AudioHandler
    {
        [SerializeField] private BiomeAudiosSo _data;

        private readonly Dictionary<BiomeType, AudioClip> _biomeAudios = new();

        protected override void Awake()
        {
            base.Awake();

            foreach(BiomeAudioDataSo audioData in _data.BiomeAudios)
            {
                _biomeAudios.Add(audioData.BiomeType, audioData.MusicClip);
            }

            _audioSource = GetComponent<AudioSource>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            GameStateEvents.OnBiomeTypeBroadcast += ChangeMusic;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameStateEvents.OnBiomeTypeBroadcast -= ChangeMusic;
        }

        private void ChangeMusic(BiomeType biomeType)
        {
            _audioSource.clip = _biomeAudios[biomeType];
            _audioSource.Play();
        }
    }
}

