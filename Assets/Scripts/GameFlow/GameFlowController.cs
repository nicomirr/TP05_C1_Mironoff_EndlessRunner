using UnityEngine;
using System.Collections;
using Game.Data;
using Game.Events;
using Game.Core;

namespace Game.GameFlow
{
    public class GameFlowController : MonoBehaviour, ICoroutineRunner, ICoroutineStopper
    {
        [SerializeField] private GameStateConfigSo _data;

        [SerializeField] private WorldSpeed _worldSpeed;

        private SpeedProgression _speedProgression;

        private BiomeTransitioner _biomeTransitioner;

        private bool _isWorking;

        private void Awake()
        {
            _worldSpeed.Initialize(_data);

            _speedProgression = new SpeedProgression(_data);
            _biomeTransitioner = new BiomeTransitioner(_data, this, this);
        }

        private void OnEnable()
        {            
            PlayerEvents.OnPlayerDeath += SlowdownWorldMovement;
            WorldEvents.OnWorldSpeedRequested += BroadcastCurrentSpeed;

            _biomeTransitioner.OnWorldMovementResetRequested += ResetWorldMovement;

            _speedProgression.OnLimitReached += _biomeTransitioner.ChangeBiome;
        }

        private void Start()
        {
            _isWorking = true;
            WorldEvents.RaiseBiomeTypeBroadcast(_biomeTransitioner.CurrentBiome);
        }

        private void Update()
        {
            if (!_isWorking)
                return;

            HandleSpeedProgression();
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= SlowdownWorldMovement;
            WorldEvents.OnWorldSpeedRequested -= BroadcastCurrentSpeed;

            _biomeTransitioner.OnWorldMovementResetRequested -= ResetWorldMovement;

            _speedProgression.OnLimitReached -= _biomeTransitioner.ChangeBiome;

        }

        private void HandleSpeedProgression()
        {
            float speed = _worldSpeed.WorldCurrentSpeed;

            if (!_speedProgression.HandleSpeedProgression(ref speed)) return;

            _worldSpeed.UpdateSpeed(speed);
            WorldEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);      
        }                

        private void SlowdownWorldMovement()
        {
            _isWorking = false;

            _biomeTransitioner.StopTransition();

            _worldSpeed.UpdateSpeed(_data.SlowedDownWorldSpeed);
            WorldEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }

        private void ResetWorldMovement()
        {
            _worldSpeed.Reset();
            _speedProgression.Reset();
        }
       
        private void BroadcastCurrentSpeed()
        {
            WorldEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void FinalizeCoroutine(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    }
}

