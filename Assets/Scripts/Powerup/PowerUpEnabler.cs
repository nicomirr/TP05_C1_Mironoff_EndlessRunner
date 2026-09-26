using UnityEngine;
using Game.Marker;
using Game.Data;

//CAMBIAR

namespace Game.Powerup
{
    public class PowerUpEnabler : MonoBehaviour
    {
        [SerializeField] private PowerUpEnablerDataSo _data;

        private static readonly int POWER_UP_TRIGGER = Animator.StringToHash("powerUp");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerMarker>(out _))
            {
                _animator.SetTrigger(POWER_UP_TRIGGER);
                PowerUpEvents.RaisePowerUpAquired(_data.PowerUpType);
            }
        }
    }
}

