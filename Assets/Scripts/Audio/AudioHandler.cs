using Game.Events;
using UnityEngine;

namespace Game.Audio
{
    public class AudioHandler : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopAudio;
            
            PauseEvents.OnGamePausedByInput += PauseAudio;
            PauseEvents.OnGameUnpausedByInput += UnpauseAudio;
            PauseEvents.OnContinueButtonClicked += UnpauseAudio;
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopAudio;

            PauseEvents.OnGamePausedByInput -= PauseAudio;
            PauseEvents.OnGameUnpausedByInput -= UnpauseAudio;
            PauseEvents.OnContinueButtonClicked -= UnpauseAudio;
        }

        private void UnpauseAudio()
        {
            _audioSource.UnPause();
        }

        private void PauseAudio()
        {
            _audioSource.Pause();
        }

        private void StopAudio()
        {
            _audioSource.Stop();
        }
    }
}

