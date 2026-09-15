using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.GameState
{
    public class RunnerState : MonoBehaviour
    {
        [SerializeField] private RunnerStateConfigSo _data;
        private SpeedProgression _speedProgression;
        private SpeedProgressionTimer _speedProgressionTimer;

        private float _currentWorldSpeed;

        private void Awake()
        {
            _speedProgression = new SpeedProgression(_data);
            _speedProgressionTimer = new SpeedProgressionTimer(_data);

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

        private void BroadcastWorldSpeed()
        {
            RunnerEvents.RaiseWorldSpeedBroadcast(_currentWorldSpeed);
        }
    }
}

