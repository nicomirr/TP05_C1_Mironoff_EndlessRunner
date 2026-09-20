using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMainPanel : UIPanel
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnSettings;
    
        protected AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();                
        }

        protected virtual void OnEnable()
        {
            _btnPlay.onClick.AddListener(OnPlayClicked);
            _btnSettings.onClick.AddListener(OnSettingsClicked);         
        }

        protected virtual void OnDisable()
        {
            _btnPlay.onClick.RemoveAllListeners();
            _btnSettings.onClick.RemoveAllListeners();            
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
    }
}
