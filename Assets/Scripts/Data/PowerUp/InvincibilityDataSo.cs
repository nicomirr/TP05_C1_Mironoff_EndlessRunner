using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "InvincibilityDataSo", menuName = "Scriptable Objects/InvincibilityDataSo")]
    public class InvincibilityDataSo : ScriptableObject
    {
        [SerializeField] private float _time;
        public float Time => _time;

        [SerializeField] private Color32 _invincibilityColor;
        public Color32 InvincibilityColor => _invincibilityColor;
    }
}

