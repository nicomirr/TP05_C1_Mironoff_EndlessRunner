using UnityEngine;
using UnityEngine.EventSystems;
using Game.Core;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UICursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CursorAppearanceSo _cursorAppearance;

        public void OnPointerEnter(PointerEventData eventData)
        {
            UIEvents.RaiseCursorAppearanceChangeRequest(_cursorAppearance.CursorType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIEvents.RaiseCursorAppearanceChangeRequest(CursorType.Normal);
        }
    }
}


