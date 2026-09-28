using UnityEngine;
using Game.Events;

namespace Game.UI
{
    public class UIMainMenuManager : UIManager
    {
        [SerializeField] private UIPanel _creditsPanel;
        [SerializeField] private UIPanel _helpPanel;

        protected override void Awake()
        {
            base.Awake();
            UIEvents.OnCreditsClicked += OpenCredits;
            UIEvents.OnHelpClicked += OpenHelp;
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
            UIEvents.OnHelpClicked -= OpenHelp;
        }

        private void OpenCredits()
        {
            OpenPanel(_creditsPanel);
        }

        private void OpenHelp()
        {
            OpenPanel(_helpPanel);
        }
    }
}

