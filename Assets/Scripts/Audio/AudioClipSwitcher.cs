using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;
using Game.Events;

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
            WorldEvents.OnBiomeTypeBroadcast += ChangeMusic;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            WorldEvents.OnBiomeTypeBroadcast -= ChangeMusic;
        }

        private void ChangeMusic(BiomeType biomeType)
        {
            _audioSource.clip = _biomeAudios[biomeType];
            _audioSource.Play();
        }
    }
}

