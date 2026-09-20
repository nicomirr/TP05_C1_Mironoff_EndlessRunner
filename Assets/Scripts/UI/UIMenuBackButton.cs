using UnityEngine;
using UnityEngine.UI;
using Game.Events;

namespace Game.UI
{
    public class UIMenuBackButton : MonoBehaviour
    {
        private Button _btnBack;

        private void Awake()
        {
            _btnBack = GetComponent<Button>();
            _btnBack.onClick.AddListener(OnBackClicked);
        }

        private void OnDestroy()
        {
            _btnBack.onClick.RemoveListener(OnBackClicked);
        }

        private void OnBackClicked()
        {
            UIEvents.RaiseBackClicked();
        }
    }
}

