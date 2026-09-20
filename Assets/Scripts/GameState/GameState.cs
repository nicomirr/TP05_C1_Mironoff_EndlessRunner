using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.GameState
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private GameStateConfigSo _data;

        [SerializeField] private WorldSpeed _worldSpeed;

        private SpeedProgression _speedProgression;
        private SpeedProgressionTimer _speedProgressionTimer;

        private bool _isWorking;

        private void Awake()
        {
            _worldSpeed.Initialize(_data);

            _speedProgression = new SpeedProgression(_data);
            _speedProgressionTimer = new SpeedProgressionTimer(_data);
        }

        private void OnEnable()
        {
            UIEvents.OnMainMenuEntered += SlowdownWorldMovement;
            PlayerEvents.OnPlayerDeath += SlowdownWorldMovement;
            RunnerEvents.OnWorldSpeedRequested += BroadcastCurrentSpeed;
        }

        private void Start()
        {
            _isWorking = true;
        }

        private void Update()
        {
            if (!_isWorking) return;        

            HandleSpeedProgression();
        }

        private void OnDisable()
        {
            UIEvents.OnMainMenuEntered -= SlowdownWorldMovement;
            PlayerEvents.OnPlayerDeath -= SlowdownWorldMovement;
            RunnerEvents.OnWorldSpeedRequested -= BroadcastCurrentSpeed;
        }

        private void HandleSpeedProgression()
        {
            if (_speedProgressionTimer.UpdateTimer())
            {
                float speed = _worldSpeed.WorldCurrentSpeed;

                if(_speedProgression.TryIncreaseWorldSpeed(ref speed))
                {
                    _worldSpeed.UpdateSpeed(speed);
                    RunnerEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
                }
            }
        }

        private void SlowdownWorldMovement()
        {
            _isWorking = false;

            _worldSpeed.UpdateSpeed(_data.SlowedDownWorldSpeed);
            RunnerEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }

        private void BroadcastCurrentSpeed()
        {           
            RunnerEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }
    }
}

