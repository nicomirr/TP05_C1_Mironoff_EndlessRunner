using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "UIScoreConfigSo", menuName = "Scriptable Objects/UIScoreConfigSo")]
    public class UIScoreConfigSo : ScriptableObject
    {
        [SerializeField] private float _scoreUnitsPerKilometer;
        public float ScoreUnitsPerKilometer => _scoreUnitsPerKilometer;
    }
}


