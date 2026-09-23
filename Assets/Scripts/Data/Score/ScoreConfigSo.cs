using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScoreConfigSo", menuName = "Scriptable Objects/ScoreConfigSo")]
    public class ScoreConfigSo : ScriptableObject
    {
        [SerializeField] private float _baseScoringTime;
        public float BaseScoringTime => _baseScoringTime;

        [SerializeField] private float _scoreUnitsPerKilometer;
        public float ScoreUnitsPerKilometer => _scoreUnitsPerKilometer;
    }

}

