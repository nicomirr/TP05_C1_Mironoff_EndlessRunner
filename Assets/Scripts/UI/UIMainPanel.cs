using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMainPanel : UIPanel
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnSettings;
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();

            _btnPlay.onClick.AddListener(OnPlayClicked);
            _btnSettings.onClick.AddListener(OnSettingsClicked);
            _btnCredits.onClick.AddListener(OnCreditsClicked);
            _btnExit.onClick.AddListener(OnExitClicked);            
        }
               
        private void OnDestroy()
        {
            _btnPlay.onClick.RemoveAllListeners();
            _btnSettings.onClick.RemoveAllListeners();
            _btnCredits.onClick.RemoveAllListeners();
            _btnExit.onClick.RemoveAllListeners();
        }

        protected virtual void OnPlayClicked()
        {
            _audioSource.Play();

            UIEvents.RaiseChangeCursorVisibilityRequest(false);       

            HidePanel();
        }

        private void OnSettingsClicked()
        {      
            _audioSource.Play();
            HidePanel();
            UIEvents.RaiseSettingsClicked();
        }

        private void OnCreditsClicked()
        {
            _audioSource.Play();
            HidePanel();
            UIEvents.RaiseCreditsClicked();
        }

        private void OnExitClicked()
        {
            _audioSource.Play();

            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
