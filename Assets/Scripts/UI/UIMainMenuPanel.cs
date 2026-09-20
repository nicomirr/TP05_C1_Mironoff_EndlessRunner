using UnityEngine;
using UnityEngine.UI;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIMainMenuPanel : UIMainPanel
    {
        
        [SerializeField] private Button _btnCredits;
        [SerializeField] private Button _btnExit;

        [SerializeField] private SceneToLoadSo _gameplayScene;

        private void Start()
        {
            UIEvents.RaiseMainMenuEntered();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _btnCredits.onClick.AddListener(OnCreditsClicked);
            _btnExit.onClick.AddListener(OnExitClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _btnCredits.onClick.RemoveAllListeners();
            _btnExit.onClick.RemoveAllListeners();
        }

        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            SceneTransitionEvents.RaiseSceneChangeRequested(_gameplayScene);
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

