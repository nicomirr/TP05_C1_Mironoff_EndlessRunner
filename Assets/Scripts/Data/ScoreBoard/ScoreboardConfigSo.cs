using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ScoreboardConfigSo", menuName = "Scriptable Objects/ScoreboardConfigSo")]
    public class ScoreboardConfigSo : ScriptableObject
    {
        [SerializeField] private float _boardDelayTime;
        public float BoardDelayTime => _boardDelayTime;

        [SerializeField] private float _boardButtonsDelayTime;
        public float BoardButtonsDelayTime => _boardButtonsDelayTime;
    }

}

