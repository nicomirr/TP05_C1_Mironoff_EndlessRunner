using UnityEngine;
using Game.Audio;
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
        private PlayerJump _jumper;
        private PlayerGroundCheck _playerGroundCheck;

        private AudioPlayer _audioPlayer;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _jumper = new PlayerJump(GetComponent<Rigidbody2D>(), _data);
            _playerGroundCheck = new PlayerGroundCheck(_groundCheck, _data);

            _audioPlayer = new AudioPlayer(_data, GetComponentInChildren<AudioSource>());
        }

        private void OnEnable()
        {
            _playerGroundCheck.OnJustLanded += HandleLand;
        }

        private void Update()
        {
            _playerGroundCheck.UpdateGroundedState();
            HandleJump();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= HandleLand;
        }

        private void OnDestroy()
        {
            _playerInputs.Deinitialize();
        }

        private void HandleJump()
        {
            if(_playerInputs.JumpPressed && _playerGroundCheck.IsGrounded)
            {
                _jumper.Jump();
                _audioPlayer.PlayAudio(AudioCategory.JumpSFX);
            }
        }

        private void HandleLand()
        {
            _audioPlayer.PlayAudio(AudioCategory.LandSFX);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            this.gameObject.SetActive(false);
        }        
    }
}

