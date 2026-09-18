using UnityEngine;
using Game.Audio;
using Game.Marker;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _data;
        [SerializeField] private Transform _groundCheck;

        private PlayerInputs _playerInputs;
        private PlayerJump _playerJumper;
        private PlayerGroundCheck _playerGroundCheck;
        private PlayerPowerUpEffect _playerPowerUpEffect;
        private PlayerInvincibility _playerInvincibility;

        private AudioPlayer _audioPlayer;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _playerJumper = new PlayerJump(GetComponent<Rigidbody2D>(), _data);
            _playerGroundCheck = new PlayerGroundCheck(_groundCheck, _data);

            GameObject powerUpEffectObject = GetComponentInChildren<PlayerPowerUpEffectMarker>().gameObject;
            _playerPowerUpEffect = new PlayerPowerUpEffect(powerUpEffectObject.GetComponent<Animator>());

            GameObject playerImageObject = GetComponentInChildren<PlayerImageMarker>().gameObject;
            _playerInvincibility = new PlayerInvincibility(playerImageObject.GetComponent<SpriteRenderer>());

            _audioPlayer = new AudioPlayer(_data, GetComponentInChildren<AudioSource>());
        }

        private void OnEnable()
        {
            _playerGroundCheck.OnJustLanded += HandleLand;
            PowerUpEvents.OnInvincibilityEnabled += EnableInvincibility;
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleJump();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= HandleLand;
            PowerUpEvents.OnInvincibilityEnabled -= EnableInvincibility;
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
                _audioPlayer.PlayAudio(AudioCategory.JumpSFX);
            }
        }

        private void HandleLand()
        {
            _audioPlayer.PlayAudio(AudioCategory.LandSFX);
        }

        private void EnableInvincibility(float time, Color32 color)
        {
            if (_playerInvincibility.IsInvincible) return;

            _playerPowerUpEffect.PlayPowerUpEffect();
            StartCoroutine(_playerInvincibility.InvincibilityTimerRoutine(time, color));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_playerInvincibility.IsInvincible) return;

            if(collision.TryGetComponent<ObstacleMarker>(out _))
            {
                this.gameObject.SetActive(false);
            }
        }        
    }
}

