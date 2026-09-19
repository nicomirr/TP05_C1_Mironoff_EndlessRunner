using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CursorAppearanceSo", menuName = "Scriptable Objects/CursorAppearanceSo")]
    public class CursorAppearanceSo : ScriptableObject
    {
        [SerializeField] private CursorType _cursorType;
        public CursorType CursorType => _cursorType;

        [SerializeField] private Texture2D _cursorTexture;
        public Texture2D CursorTexture => _cursorTexture;
    }
}

