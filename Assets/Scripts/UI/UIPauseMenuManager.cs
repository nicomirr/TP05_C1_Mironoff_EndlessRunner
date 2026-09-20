using Game.Events;

namespace Game.UI
{
    public class UIPauseMenuManager : UIManager
    {
        protected override void Awake()
        {
            base.Awake();

            PauseEvents.OnGamePausedByInput += OpenPause;
            PauseEvents.OnGameUnpausedByInput += ClosePause;
        }

        protected override void OnDestroy()
        {
            PauseEvents.OnGamePausedByInput -= OpenPause;
            PauseEvents.OnGameUnpausedByInput -= ClosePause;

            base.OnDestroy();
        }

        private void OpenPause()
        {
            _mainPanel.DisplayPanel();
            _currentPanel = _mainPanel;
        }

        private void ClosePause()
        {
            _currentPanel.HidePanel();
            _currentPanel = null;
        }
    }
}

