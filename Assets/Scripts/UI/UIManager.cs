using UnityEngine;
using Game.Events;

namespace Game.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] protected UIPanel _mainPanel;
        [SerializeField] private UIPanel _settingsPanel;

        protected UIPanel _currentPanel;
        protected UIPanel _previousPanel;

        protected virtual void Awake()
        {          
            UIEvents.OnSettingsClicked += OpenSettings;

            UIEvents.OnBackClicked += GoBack;
        }

        protected virtual void OnDestroy()
        {            
            UIEvents.OnSettingsClicked -= OpenSettings;

            UIEvents.OnBackClicked -= GoBack;
        }
        
        private void OpenSettings()
        {
            OpenPanel(_settingsPanel);
        }        

        protected void OpenPanel(UIPanel panel)
        {
            _previousPanel = _currentPanel;

            _previousPanel.HidePanel();
            panel.DisplayPanel();

            _currentPanel = panel;
        }

        private void GoBack()
        {            
            _currentPanel.HidePanel();
            _previousPanel.DisplayPanel();

            _currentPanel = _previousPanel;
            _previousPanel = null;
        }
    }
}

