using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Marker;
using Game.Data;
using Game.Core;
using Game.Events;
using Game.ParticleEffects;
using Game.VisualEffects;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PlayerConfigSo _data;

        private PlayerInputs _playerInputs;
        private PlayerStateMachine _playerFsm; 
        private PlayerPowerUps _playerPowerUps;
        private PlayerHealth _playerHealth;
        private PlayerObstacleHandler _playerObstacleHandler;
        private PlayerJump _playerJumper;
        private PlayerGroundCheck _playerGroundCheck;


        private void Awake()
        {            
            _playerInputs = new PlayerInputs();
            _playerFsm = new PlayerStateMachine(_data);
            _playerHealth = new PlayerHealth(_data);
           
            GameObject powerUpEffectObject = GetComponentInChildren<PlayerPowerUpEffectMarker>().gameObject;

            PlayerPowerUpEffect powerUpEffect = new PlayerPowerUpEffect(powerUpEffectObject.GetComponent<Animator>());

            AudioPlayer audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());

            GameObject playerImageObject = GetComponentInChildren<PlayerImageMarker>().gameObject;

            SpriteRenderer playerSpriteRenderer = playerImageObject.GetComponent<SpriteRenderer>();

            SpriteFlicker spriteFlicker = new SpriteFlicker(playerSpriteRenderer);

            List<ParticleEffect> effects = new(GetComponentsInChildren<ParticleEffect>());

            ParticleEffectsPlayer particleEffectsPlayer = new ParticleEffectsPlayer(effects);

            Transform skullSpawnPos = GetComponentInChildren<SkullSpawnerMarker>().transform;

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
                       
            PlayerInvincibilityPowerUp invincibilityPow = new PlayerInvincibilityPowerUp(this, _playerFsm, spriteFlicker,
                    playerSpriteRenderer, _data.PowerUpsData.InvincibilityDataSo);

            PlayerHealPowerUp healthPow = new PlayerHealPowerUp(this, _playerFsm, spriteFlicker, playerSpriteRenderer,
                    _data.PowerUpsData.HealthPowData, _playerHealth);

            PlayerDeath playerDeath = new PlayerDeath(skullSpawnPos, _data);

            PlayerDamageHandler damageHandler = new PlayerDamageHandler(_data, _playerHealth, playerDeath, spriteFlicker,
                    audioPlayer, this, _playerFsm, gameObject);

            _playerPowerUps = new PlayerPowerUps(audioPlayer, powerUpEffect);
            _playerPowerUps.AddPowerUp(PowerUpType.Invincibility, invincibilityPow);
            _playerPowerUps.AddPowerUp(PowerUpType.Health, healthPow);

            _playerObstacleHandler = new PlayerObstacleHandler(_playerFsm, damageHandler, audioPlayer, particleEffectsPlayer);

            _playerJumper = new PlayerJump(GetComponent<Rigidbody2D>(), _data, particleEffectsPlayer, audioPlayer);

            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);
        }

        private void OnEnable()
        {
            _playerGroundCheck.OnJustLanded += _playerJumper.HandleLand;

            PowerUpEvents.OnPowerUpAcquired += _playerPowerUps.TryEnablePowerUp;

            PauseEvents.OnGamePausedByInput += _playerInputs.DisablePlayerInputs;
            PauseEvents.OnGameUnpausedByInput += _playerInputs.EnablePlayerInputs;
            PauseEvents.OnContinueButtonClicked += _playerInputs.EnablePlayerInputs;
        }

        private void Start()
        {
            PlayerEvents.RaisePlayerHealthInitialized(_playerHealth.MaxHealth);
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleInput();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= _playerJumper.HandleLand;

            PowerUpEvents.OnPowerUpAcquired -= _playerPowerUps.TryEnablePowerUp;

            PauseEvents.OnGamePausedByInput -= _playerInputs.DisablePlayerInputs;
            PauseEvents.OnGameUnpausedByInput -= _playerInputs.EnablePlayerInputs;
            PauseEvents.OnContinueButtonClicked -= _playerInputs.EnablePlayerInputs;
        }

        private void OnDestroy()
        {            
            _playerInputs.Deinitialize();
            _playerPowerUps.Deinitialize();
        }

        private void HandleInput()
        {
            if (!_playerInputs.JumpPressed)
                return;

            if (!_playerGroundCheck.IsGrounded)
                return;


            _playerJumper.Jump();

        }               

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ObstacleMarker>(out _))
            {
                _playerObstacleHandler.HandleCollision(collision.gameObject);
            }
        }

        public Coroutine RunCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}

