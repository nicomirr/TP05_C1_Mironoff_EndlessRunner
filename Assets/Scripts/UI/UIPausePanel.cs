using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Events;

namespace Game.UI
{
    public class UIPausePanel : UIMainPanel
    {
        [SerializeField] private SceneToLoadSo _sceneToLoad;
        [SerializeField] private Button _mainMenuButton;

        protected override void Awake()
        {
            base.Awake();
            _mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        }
                   
        private void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveAllListeners();           
        }

        protected override void OnPlayClicked()
        {
            PauseEvents.RaiseContinueClicked();
            base.OnPlayClicked();
        }

        private void OnMainMenuClicked()
        {
            

            PauseEvents.RaiseContinueClicked();
            UIEvents.RaiseChangeCursorVisibilityRequest(true);

            SceneTransitionEvents.RaiseSceneChangeRequested(_sceneToLoad);
        }
    }
}

