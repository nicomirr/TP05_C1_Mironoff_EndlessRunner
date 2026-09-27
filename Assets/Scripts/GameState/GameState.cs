using UnityEngine;
using Game.Data;
using Game.Events;
using System.Collections;

namespace Game.GameState
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private GameStateConfigSo _data;

        [SerializeField] private WorldSpeed _worldSpeed;

        private SpeedProgression _speedProgression;
        private SpeedProgressionTimer _speedProgressionTimer;

        private BiomeProgression _biomeProgression;

        private Coroutine _changeBiomeCoroutine;

        private bool _isWorking;

        private void Awake()
        {
            _worldSpeed.Initialize(_data);

            _speedProgression = new SpeedProgression(_data);
            _speedProgressionTimer = new SpeedProgressionTimer(_data);

            _biomeProgression = new BiomeProgression(_data);
        }

        private void OnEnable()
        {            
            PlayerEvents.OnPlayerDeath += SlowdownWorldMovement;
            GameStateEvents.OnWorldSpeedRequested += BroadcastCurrentSpeed;

            _speedProgression.OnLimitReached += ChangeBiome;
        }

        private void Start()
        {
            _isWorking = true;
            GameStateEvents.RaiseBiomeTypeBroadcast(_biomeProgression.CurrentBiome);
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
            GameStateEvents.OnWorldSpeedRequested -= BroadcastCurrentSpeed;

            _speedProgression.OnLimitReached -= ChangeBiome;

            _changeBiomeCoroutine = null;
        }

        private void HandleSpeedProgression()
        {
            if (_speedProgressionTimer.UpdateTimer())
            {
                float speed = _worldSpeed.WorldCurrentSpeed;

                if (_speedProgression.TryIncreaseWorldSpeed(ref speed))
                {
                    _worldSpeed.UpdateSpeed(speed);
                    GameStateEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
                }
            }
        }

        private void ChangeBiome()
        {
            if (_biomeProgression.LastPhaseReached) return;

            if (_changeBiomeCoroutine != null) return;

            _changeBiomeCoroutine = StartCoroutine(ChangeBiomeRoutine());
        }

        private IEnumerator ChangeBiomeRoutine()
        {
            yield return _biomeProgression.ChangeBiomeRoutine();

            GameStateEvents.RaiseStopSpawners();

            yield return new WaitForSeconds(4);

            UIEvents.RaiseRequestFadeOut();

            yield return new WaitForSeconds(4);

            _worldSpeed.Reset();
            _speedProgression.Reset();
            
            GameStateEvents.RaiseBiomeTypeBroadcast(_biomeProgression.CurrentBiome);

            UIEvents.RaiseRequestFadeIn();

            _changeBiomeCoroutine = null;
        }

        private void SlowdownWorldMovement()
        {
            _isWorking = false;

            StopBiomeProgression();

            _worldSpeed.UpdateSpeed(_data.SlowedDownWorldSpeed);
            GameStateEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }

        private void StopBiomeProgression()
        {
            if (_changeBiomeCoroutine == null)
                return;

            StopCoroutine(_changeBiomeCoroutine);

            _changeBiomeCoroutine = null;
        }

        private void BroadcastCurrentSpeed()
        {           
            GameStateEvents.RaiseWorldSpeedBroadcast(_worldSpeed.WorldCurrentSpeed);
        }
    }
}

