using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Audio
{
    public class AudioPlayer
    {       
        private AudioSource _audioSource;
        private Dictionary<AudioCategory, AudioClip> _audios;

        public AudioPlayer(PlayerConfigSo data, AudioSource audioSource)
        {
            _audioSource = audioSource;

            _audios = new Dictionary<AudioCategory, AudioClip>();

            foreach (AudioDataSo audioData in data.AudioConfigData.Audios)
            {
                _audios.Add(audioData.AudioCategory, audioData.AudioClip);
            }
        }

        public void PlayAudio(AudioCategory category)
        {
            _audioSource.PlayOneShot(_audios[category]);
        }
    }
}

