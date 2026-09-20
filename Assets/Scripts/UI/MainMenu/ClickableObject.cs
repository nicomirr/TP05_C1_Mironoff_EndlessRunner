using Game.Audio;
using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Game.UI.MainMenu
{
    public class ClickableObject : MonoBehaviour
    {
        [SerializeField] private AudioConfigSo _clickableData;

        private List<AudioCategory> _availableAudios;
        private AudioPlayer _audioPlayer;

        private Collider2D _collider;

        private void Awake()
        {
            _audioPlayer = new AudioPlayer(_clickableData, GetComponent<AudioSource>());

            _availableAudios = new List<AudioCategory>();

            foreach(AudioDataSo audioData in _clickableData.Audios)
            {
                _availableAudios.Add(audioData.AudioCategory);
            }

            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (DetectClickOverObject())
            {
                ClickReaction();
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

        protected virtual void ClickReaction()
        {
            int randomIndex = Random.Range(0, _availableAudios.Count);

            _audioPlayer.PlayAudio(_availableAudios[randomIndex]);
        }
    }

}

