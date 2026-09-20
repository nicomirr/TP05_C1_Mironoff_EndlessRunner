using UnityEngine;

namespace Game.UI
{
    public class UIMainMenuManager : UIManager
    {
        private void Start()
        {
            _currentPanel = _mainPanel;
            _mainPanel.DisplayPanel();
        }
    }
}

