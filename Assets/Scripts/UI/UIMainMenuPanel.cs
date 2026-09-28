using UnityEngine;
using UnityEngine.UI;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIMainMenuPanel : UIMainPanel
    {
        [SerializeField] private Button _btnHelp;
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        [SerializeField] private SceneToLoadSo _gameplayScene;
                
        protected override void OnEnable()
        {
            base.OnEnable();

            _btnHelp.onClick.AddListener(OnHelpClicked);
            _btnCredits.onClick.AddListener(OnCreditsClicked);
            _btnExit.onClick.AddListener(OnExitClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _btnHelp.onClick.RemoveAllListeners();
            _btnCredits.onClick.RemoveAllListeners();
            _btnExit.onClick.RemoveAllListeners();
        }

        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            SceneTransitionEvents.RaiseSceneChangeRequested(_gameplayScene);
        }

        private void OnHelpClicked()
        {
            _audioSource.Play();
            HidePanel();
            UIEvents.RaiseHelpClicked();
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

