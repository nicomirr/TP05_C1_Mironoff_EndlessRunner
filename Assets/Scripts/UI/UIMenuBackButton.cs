using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMenuBackButton : MonoBehaviour
    {
        private AudioSource _audioSource;
        private Button _btnBack;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _btnBack = GetComponent<Button>();
            _btnBack.onClick.AddListener(OnBackClicked);
        }

        private void OnDestroy()
        {
            _btnBack.onClick.RemoveListener(OnBackClicked);
        }

        private void OnBackClicked()
        {
            _audioSource.Play();
            UIEvents.RaiseBackClicked();
        }
    }
}

