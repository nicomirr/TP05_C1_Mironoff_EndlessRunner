using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerConfigSo", menuName = "Scriptable Objects/PlayerConfigSo")]
    public class PlayerConfigSo : ScriptableObject
    {
        [SerializeField] private AudioConfigSo _audioConfigData;
        public AudioConfigSo AudioConfigData => _audioConfigData;

        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;

        [SerializeField] private float _groundCheckDistance;
        public float groundCheckDistance => _groundCheckDistance;

        [SerializeField] private LayerMask _groundLayer;
        public LayerMask GroundLayer => _groundLayer;

    }

}

