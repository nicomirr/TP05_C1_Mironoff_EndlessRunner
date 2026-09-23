using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMenuBackButton : MonoBehaviour
    {
        private AudioSource _audioSource;
        private Button _buttonBack;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _buttonBack = GetComponent<Button>();
            _buttonBack.onClick.AddListener(OnBackClicked);
        }

        private void OnDestroy()
        {
            _buttonBack.onClick.RemoveListener(OnBackClicked);
        }

        private void OnBackClicked()
        {
            _audioSource.Play();
            UIEvents.RaiseBackClicked();
        }
    }
}

