using UnityEngine;
using System.Collections.Generic;
using Game.Events;
using Game.Data;
using Game.Core;

namespace Game.UI
{
    public class UICursorAppearance : MonoBehaviour
    {
        [SerializeField] private CursorAppearanceConfigSo _data;

        private Dictionary<CursorType, Texture2D> _cursorAppearances;

        private Texture2D _currentCursorTexture;

        private void Awake()
        {
            _cursorAppearances = new Dictionary<CursorType, Texture2D>();

            foreach (CursorAppearanceSo cursorData in _data.CursorAppearances)
            {
                _cursorAppearances.Add(cursorData.CursorType, cursorData.CursorTexture);
            }
        }

        private void OnEnable()
        {
            UIEvents.OnChangeCursorVisibilityRequest += ChangeCursorState;
            UIEvents.OnCursorApperanceChangeRequest += ChangeCurrentCursorTexture;
        }

        private void Start()
        {
            _currentCursorTexture = _cursorAppearances[CursorType.Normal];
            SetCursorTexture();
        }

        private void OnDisable()
        {
            UIEvents.OnChangeCursorVisibilityRequest -= ChangeCursorState;            
        }
        
        private void ChangeCurrentCursorTexture(CursorType cursorType)
        {
            _currentCursorTexture = _cursorAppearances[cursorType];
            SetCursorTexture();
        }

        private void ChangeCursorState(bool isVisible)
        {
            Cursor.visible = isVisible;

            if (isVisible)
                SetCursorTexture();
        }

        private void SetCursorTexture()
        {
            Cursor.SetCursor(_currentCursorTexture, Vector2.zero, CursorMode.Auto);
        }        
    }
}

