using Game.Audio;
using Game.Core;
using Game.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace Game.UI
{
    public class UIClickableObject : MonoBehaviour
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

            if (IsPointerOverUI()) return false;

            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

            return hit == _collider;
        }

        private bool IsPointerOverUI()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);            

            pointerData.position = Mouse.current.position.ReadValue();

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                if (result.module is GraphicRaycaster)
                    return true;
            }

            return false;
        }

        protected virtual void ClickReaction()
        {
            int randomIndex = Random.Range(0, _availableAudios.Count);

            _audioPlayer.PlayAudio(_availableAudios[randomIndex]);
        }
    }

}

