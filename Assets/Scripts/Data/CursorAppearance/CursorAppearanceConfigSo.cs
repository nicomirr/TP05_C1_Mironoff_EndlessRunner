using UnityEngine;
using System.Collections.Generic;
using Game.Data;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CursorAppearanceConfigSo", menuName = "Scriptable Objects/CursorAppearanceConfigSo")]
    public class CursorAppearanceConfigSo : ScriptableObject
    {
        [SerializeField] private List<CursorAppearanceSo> _cursorAppearances;
        public List<CursorAppearanceSo> CursorAppearances => _cursorAppearances;
    }
}

