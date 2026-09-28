using System;
using Game.Core;

namespace Game.Events
{
    public static class CursorEvents
    {
        public static event Action<bool> OnChangeCursorVisibilityRequest;
        public static event Action<CursorType> OnCursorApperanceChangeRequest;

        public static void RaiseChangeCursorVisibilityRequest(bool isVisible)
        {
            OnChangeCursorVisibilityRequest?.Invoke(isVisible);
        }
        public static void RaiseCursorAppearanceChangeRequest(CursorType cursorType)
        {
            OnCursorApperanceChangeRequest?.Invoke(cursorType);
        }
    }
}
