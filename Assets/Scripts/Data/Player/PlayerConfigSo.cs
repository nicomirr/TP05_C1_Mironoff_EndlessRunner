using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerConfigSo", menuName = "Scriptable Objects/PlayerConfigSo")]
    public class PlayerConfigSo : ScriptableObject
    {
        [SerializeField] private StateMachineTransitionsConfigSo _fsmTransitionsData;
        public StateMachineTransitionsConfigSo FsmTransitionsData => _fsmTransitionsData;

        [SerializeField] private PowerUpsDataSo _powerUpsData;
        public PowerUpsDataSo PowerUpsData => _powerUpsData;

        [SerializeField] private AudioConfigSo _audioConfigData;
        public AudioConfigSo AudioConfigData => _audioConfigData;

        [SerializeField] private DamageFlickerDataSo _damageFlickerData;
        public DamageFlickerDataSo DamageFlickerData => _damageFlickerData;

        [SerializeField] private int _maxHealth;
        public int MaxHealth => _maxHealth;

        [SerializeField] private int _maxInitialHealth;
        public int MaxInitialHealth => _maxInitialHealth;

        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;

        [SerializeField] private float _groundCheckDistance;
        public float groundCheckDistance => _groundCheckDistance;

        [SerializeField] private LayerMask _groundLayer;
        public LayerMask GroundLayer => _groundLayer;

        [SerializeField] private GameObject _skullPrefab;
        public GameObject SkullPrefab => _skullPrefab;

    }

}

