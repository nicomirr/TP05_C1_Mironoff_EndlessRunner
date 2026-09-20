using Game.Events;
using UnityEngine;

namespace Game.UI
{
    public class UIMainMenuManager : UIManager
    {
        [SerializeField] private UIPanel _creditsPanel;

        protected override void Awake()
        {
            base.Awake();
            UIEvents.OnCreditsClicked += OpenCredits;
        }       

        private void Start()
        {
            _currentPanel = _mainPanel;
            _mainPanel.DisplayPanel();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UIEvents.OnCreditsClicked -= OpenCredits;
        }

        private void OpenCredits()
        {
            OpenPanel(_creditsPanel);
        }
    }
}

