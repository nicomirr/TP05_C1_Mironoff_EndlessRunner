using UnityEngine;
using Game.Events;

namespace Game.UI
{
    public class UICursorAppearance : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorTexture;

        private void Awake()
        {
            UIEvents.OnChangeCursorVisibilityRequest += ChangeCursorState;
        }

        private void Start()
        {
            SetCursorTexture();
        }

        private void OnDestroy()
        {
            UIEvents.OnChangeCursorVisibilityRequest -= ChangeCursorState;
        }

        private void ChangeCursorState(bool isVisible)
        {
            Cursor.visible = isVisible;

            if (isVisible)
                SetCursorTexture();
        }

        private void SetCursorTexture()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}

