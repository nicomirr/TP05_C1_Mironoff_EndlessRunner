using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Game.Audio;
using Game.Data;
using Game.Core;


namespace Game.UI.MainMenu
{
    public class ClickableObject : MonoBehaviour
    {
        [SerializeField] private AudioConfigSo _data;

        private List<AudioCategory> _availableAudios;
        private AudioPlayer _audioPlayer;

        private Collider2D _collider;

        private void Awake()
        {
            _audioPlayer = new AudioPlayer(_data, GetComponent<AudioSource>());

            _availableAudios = new List<AudioCategory>();

            foreach(AudioDataSo audioData in _data.Audios)
            {
                _availableAudios.Add(audioData.AudioCategory);
            }

            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (DetectClickOverObject())
            {
                PlayRandomAudio();
            }            
        }

        private bool DetectClickOverObject()
        {
            if (!Mouse.current.leftButton.wasPressedThisFrame) return false;

            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

            return hit == _collider;
        }

        private void PlayRandomAudio()
        {
            int randomIndex = Random.Range(0, _availableAudios.Count);

            _audioPlayer.PlayAudio(_availableAudios[randomIndex]);
        }
    }

}

