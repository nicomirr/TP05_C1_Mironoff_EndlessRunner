using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private ScoreConfigSo _data;

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;
        private ISpeedProvider _worldSpeedProvider;

        private int _playerScore;

        private float _scoreTimer;

        private float _speedMultiplier;

        private bool _isWorking;

        private void Awake()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopScoring;
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopScoring;
        }

        private void Start()
        {
            _isWorking = true;
        }

        private void Update()
        {
            if (!_isWorking) return;

            UpdateTimer();
            TryRaiseScore();
        }

        private void UpdateTimer()
        {
            _speedMultiplier = _worldSpeedProvider.WorldCurrentSpeed / _worldSpeedProvider.WorldBaseSpeed;
            _scoreTimer += Time.deltaTime * _speedMultiplier;
        }

        private void TryRaiseScore()
        {
            if(_scoreTimer >= _data.BaseScoringTime)
            {
                _playerScore++;
                UIEvents.RaisePlayerScoreUpdated(_playerScore / _data.ScoreUnitsPerKilometer);

                _scoreTimer -= _data.BaseScoringTime;
            }
        }

        private void StopScoring()
        {
            _isWorking = false;
            UIEvents.RaiseDisplayScoreboard(_playerScore / _data.ScoreUnitsPerKilometer);
        }
    }
}

