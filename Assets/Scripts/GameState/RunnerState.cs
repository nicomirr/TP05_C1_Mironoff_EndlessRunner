using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.GameState
{
    public class RunnerState : MonoBehaviour, ISpeedProvider
    {
        [SerializeField] private RunnerStateConfigSo _data;

        private SpeedProgression _speedProgression;
        private SpeedProgressionTimer _speedProgressionTimer;

        private float _currentWorldSpeed;
        public float WorldCurrentSpeed => _currentWorldSpeed;
        public float WorldBaseSpeed => _data.InitialWorldSpeed;



        private void Awake()
        {
            _speedProgression = new SpeedProgression(_data);
            _speedProgressionTimer = new SpeedProgressionTimer(_data);

            RunnerEvents.OnBaseSpeedRequested += BroadcastBaseSpeed;
            RunnerEvents.OnWorldSpeedRequested += BroadcastWorldSpeed;
        }

        private void Start()
        {
            _currentWorldSpeed = _data.InitialWorldSpeed;
            RunnerEvents.RaiseWorldSpeedBroadcast(_currentWorldSpeed);
        }

        private void Update()
        {
            HandleSpeedProgression();            
        }

        private void OnDestroy()
        {
            RunnerEvents.OnBaseSpeedRequested -= BroadcastBaseSpeed;
            RunnerEvents.OnWorldSpeedRequested -= BroadcastWorldSpeed;
        }

        private void HandleSpeedProgression()
        {
            if (_speedProgressionTimer.UpdateTimer())
            {
                if(_speedProgression.TryIncreaseWorldSpeed(ref _currentWorldSpeed))
                {
                    BroadcastWorldSpeed();
                }
            }
        }

        private void BroadcastBaseSpeed()
        {
            RunnerEvents.RaiseBaseSpeedBroadcast(_data.InitialWorldSpeed);
        }

        private void BroadcastWorldSpeed()
        {
            RunnerEvents.RaiseWorldSpeedBroadcast(_currentWorldSpeed);
        }
    }
}

