using UnityEngine;
using Game.Events;

namespace Game.Audio
{
    public class AudioHandler : MonoBehaviour
    {
        protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopAudio;
            
            PauseEvents.OnGamePausedByInput += PauseAudio;
            PauseEvents.OnGameUnpausedByInput += UnpauseAudio;
            PauseEvents.OnContinueButtonClicked += UnpauseAudio;
        }

        protected virtual void OnDisable()
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

