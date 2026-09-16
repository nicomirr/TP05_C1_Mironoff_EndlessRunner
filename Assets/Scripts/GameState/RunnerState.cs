using UnityEngine;
using Game.Data;
using Game.Events;

namespace Game.GameState
{
    public class RunnerState : MonoBehaviour
    {
        [SerializeField] private RunnerStateConfigSo _data;

        [SerializeField] private WorldSpeed _worldSpeed;

        private SpeedProgression _speedProgression;
        private SpeedProgressionTimer _speedProgressionTimer;

        private void Awake()
        {
            _worldSpeed.Initialize(_data);

            _speedProgression = new SpeedProgression(_data);
            _speedProgressionTimer = new SpeedProgressionTimer(_data);

            RunnerEvents.OnWorldSpeedRequested += BroadcastCurrentSpeed;
        }

        private void Update()
        {
            HandleSpeedProgression();
        }

        private void OnDestroy()
        {
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

        private void BroadcastCurrentSpeed()
        {           
            RunnerEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }
    }
}

