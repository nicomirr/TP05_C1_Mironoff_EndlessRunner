using Game.Events;
using UnityEngine;

namespace Game.Audio
{
    public class AudioStopper : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopAudio;
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopAudio;
        }

        private void StopAudio()
        {
            _audioSource.Stop();
        }
    }
}

