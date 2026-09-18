using UnityEngine;
using Game.Marker;
using Game.Data;

namespace Game.Powerup
{
    public class InvincibilityPowerUp : MonoBehaviour
    {
        [SerializeField] private InvincibilityDataSo _data;

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
                PowerUpEvents.RaiseInvincibilityAcquired(_data.Time, _data.WarningTime, _data.TotalWarningBlinks, _data.InvincibilityColor);
            }
        }
    }
}

