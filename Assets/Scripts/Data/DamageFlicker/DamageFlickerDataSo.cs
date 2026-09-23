using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "DamageFlickerDataSo", menuName = "Scriptable Objects/DamageFlickerDataSo")]
    public class DamageFlickerDataSo : ScriptableObject
    {
        [Range(0.1f, 0.5f)][SerializeField] private float _time;
        public float Time => _time;

        [Range(1, 3)][SerializeField] private int _totalBlinks;
        public int TotalBlinks => _totalBlinks;

        [SerializeField] private Color32 _flickerColor;
        public Color32 FlickerColor => _flickerColor;
    }

}

