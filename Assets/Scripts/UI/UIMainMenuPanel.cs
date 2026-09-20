using UnityEngine;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIMainMenuPanel : UIMainPanel
    {
        [SerializeField] private SceneToLoadSo _gameplayScene;

        private void Start()
        {
            UIEvents.RaiseMainMenuEntered();
        }

        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            SceneTransitionEvents.RaiseSceneChangeRequested(_gameplayScene);            
        }     
      
    }
}

