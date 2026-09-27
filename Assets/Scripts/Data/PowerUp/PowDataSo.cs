using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PowDataSo", menuName = "Scriptable Objects/PowDataSo")]
    public class PowDataSo : ScriptableObject
    {
        [SerializeField] protected float _time;
        public float Time => _time;

        [SerializeField] private float _warningTime;
        public float WarningTime => _warningTime;

        [Range(1, 4)][SerializeField] private int _totalWarningBlinks;
        public int TotalBlinks => _totalWarningBlinks;

        [SerializeField] private Color32 _flickerColor;
        public Color32 FlickerColor => _flickerColor;
    }

}

