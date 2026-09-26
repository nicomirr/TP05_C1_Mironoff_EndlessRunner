using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "InvincibilityDataSo", menuName = "Scriptable Objects/InvincibilityDataSo")]
    public class InvincibilityPowDataSo : PowDataSo
    {        
        [SerializeField] private float _warningTime;
        public float WarningTime => _warningTime;

        [Range(1,4)][SerializeField] private int _totalWarningBlinks;
        public int TotalWarningBlinks => _totalWarningBlinks;

        [SerializeField] private Color32 _invincibilityColor;
        public Color32 InvincibilityColor => _invincibilityColor;
    }
}

