using UnityEngine;
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
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _data;

        private PlayerInputs _playerInputs;
        private PlayerJump _playerJumper;
        private PlayerGroundCheck _playerGroundCheck;
        private PlayerPowerUpEffect _playerPowerUpEffect;
        private PlayerInvincibility _playerInvincibility;
        private PlayerDeath _playerDeath;

        private ParticleEffectsPlayer _particleEffectsPlayer;

        private AudioPlayer _audioPlayer;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _playerJumper = new PlayerJump(GetComponent<Rigidbody2D>(), _data);

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);

            GameObject powerUpEffectObject = GetComponentInChildren<PlayerPowerUpEffectMarker>().gameObject;
            _playerPowerUpEffect = new PlayerPowerUpEffect(powerUpEffectObject.GetComponent<Animator>());

            GameObject playerImageObject = GetComponentInChildren<PlayerImageMarker>().gameObject;
            _playerInvincibility = new PlayerInvincibility(playerImageObject.GetComponent<SpriteRenderer>());

            List<ParticleEffect> effects = new(this.gameObject.GetComponentsInChildren<ParticleEffect>());       
            _particleEffectsPlayer = new ParticleEffectsPlayer(effects);

            Transform skullSpawnPos = GetComponentInChildren<SkullSpawnerMarker>().transform;
            _playerDeath = new PlayerDeath(skullSpawnPos, _data);

            _audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());
        }

        private void OnEnable()
        {
            _playerGroundCheck.OnJustLanded += HandleLand;
            _playerInvincibility.OnInvincibilityFinalized += HandlePowerUpFinalized;
            PowerUpEvents.OnInvincibilityAcquired += EnableInvincibility;
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleJump();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= HandleLand;
            _playerInvincibility.OnInvincibilityFinalized -= HandlePowerUpFinalized;
            PowerUpEvents.OnInvincibilityAcquired -= EnableInvincibility;
        }

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();
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

        private void EnableInvincibility(float time, float warningTime, int totalWarningBlinks, Color32 color)
        {
            if (_playerInvincibility.IsInvincible) return;

            HandlePowerUpEnablement();

            StartCoroutine(_playerInvincibility.InvincibilityTimerRoutine(time, warningTime, totalWarningBlinks, color));
        }

        private void HandlePowerUpEnablement()
        {
            PlayerEvents.RaisePowerUpEnabled();
            _audioPlayer.PlayAudio(AudioCategory.PowUpEnabledSFX);
            _playerPowerUpEffect.PlayPowerUpEffect();
        }

        private void HandlePowerUpFinalized()
        {
            PlayerEvents.RaisePowerUpDisabled();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {            
            if(collision.TryGetComponent<ObstacleMarker>(out _))
            {
                if(_playerInvincibility.IsInvincible)
                {
                    _audioPlayer.PlayAudio(AudioCategory.PuffDestroySFX);

                    _particleEffectsPlayer.PlayEffect(ParticleEffectType.Destroyed);

                    collision.gameObject.SetActive(false);

                    return;
                }

                PlayerEvents.RaisePlayerDeath();

                _playerDeath.SpawnSkull();
                this.gameObject.SetActive(false);
            }
        }        
    }
}

