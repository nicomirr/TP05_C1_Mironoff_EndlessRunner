using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Marker;
using Game.Data;
using Game.Core;
using Game.Events;
using Game.ParticleEffects;

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

        private ParticleEffectsPlayer _particleEffectsPlayer;

        private AudioPlayer _audioPlayer;

        private void Awake()
        {            
            _playerInputs = new PlayerInputs();

            _playerFsm = new PlayerStateMachine(_data);

            GameObject powerUpEffectObject = GetComponentInChildren<PlayerPowerUpEffectMarker>().gameObject;
            PlayerPowerUpEffect powerUpEffect = new PlayerPowerUpEffect(powerUpEffectObject.GetComponent<Animator>());

            _audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());
            
            _playerPowerUps = new PlayerPowerUps(_audioPlayer, powerUpEffect);

            GameObject playerImageObject = GetComponentInChildren<PlayerImageMarker>().gameObject;
            SpriteRenderer playerSpriteRenderer = playerImageObject.GetComponent<SpriteRenderer>();
            SpriteFlicker spriteFlicker = new SpriteFlicker(playerSpriteRenderer);

            _playerHealth = new PlayerHealth(_data);

            PlayerInvincibilityPowerUp invincibilityPow = new PlayerInvincibilityPowerUp(this, _playerFsm, _data.PowerUpsData.InvincibilityDataSo,
                spriteFlicker, playerSpriteRenderer);

            PlayerHealPowerUp healthPow = new PlayerHealPowerUp(this, _playerFsm, _data.PowerUpsData.HealthPowData, _playerHealth);

            _playerPowerUps.AddPowerUp(PowerUpType.Invincibility, invincibilityPow);
            _playerPowerUps.AddPowerUp(PowerUpType.Health, healthPow);            
            
            Transform skullSpawnPos = GetComponentInChildren<SkullSpawnerMarker>().transform;
            PlayerDeath playerDeath = new PlayerDeath(skullSpawnPos, _data);

            PlayerDamageHandler damageHandler = new PlayerDamageHandler(_data, _playerHealth, playerDeath, spriteFlicker, 
                _audioPlayer, this, _playerFsm, this.gameObject);

            List<ParticleEffect> effects = new(this.gameObject.GetComponentsInChildren<ParticleEffect>());

            _particleEffectsPlayer = new ParticleEffectsPlayer(effects);

            _playerObstacleHandler = new PlayerObstacleHandler(_playerFsm, damageHandler, _audioPlayer, _particleEffectsPlayer);

            _playerJumper = new PlayerJump(GetComponent<Rigidbody2D>(), _data);

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);                     

        }

        private void OnEnable()
        {
            _playerGroundCheck.OnJustLanded += HandleLand;

            PowerUpEvents.OnPowerUpAquired += _playerPowerUps.TryEnablePowerUp;

            PauseEvents.OnGamePausedByInput += _playerInputs.DisablePlayerInputs;
            PauseEvents.OnGameUnpausedByInput += _playerInputs.EnablePlayerInputs;
            PauseEvents.OnContinueButtonClicked += _playerInputs.EnablePlayerInputs;
        }

        private void Start()
        {
            UIEvents.RaiseInitializePlayerUIHealth(_playerHealth.MaxHealth);
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleJump();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= HandleLand;

            PowerUpEvents.OnPowerUpAquired -= _playerPowerUps.TryEnablePowerUp;

            PauseEvents.OnGamePausedByInput -= _playerInputs.DisablePlayerInputs;
            PauseEvents.OnGameUnpausedByInput -= _playerInputs.EnablePlayerInputs;
            PauseEvents.OnContinueButtonClicked -= _playerInputs.EnablePlayerInputs;
        }

        private void OnDestroy()
        {            
            _playerInputs.Deinitialize();
            _playerPowerUps.Deinitialize();
        }

        private void HandleJump()
        {
            if(_playerInputs.JumpPressed && _playerGroundCheck.IsGrounded)
            {
                _playerJumper.Jump();
                _particleEffectsPlayer.PlayEffect(ParticleEffectType.Jump);
                _audioPlayer.PlayAudio(AudioCategory.JumpSFX);
            }
        }

        private void HandleLand()
        {
            _audioPlayer.PlayAudio(AudioCategory.LandSFX);
            _particleEffectsPlayer.PlayEffect(ParticleEffectType.Land);
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

