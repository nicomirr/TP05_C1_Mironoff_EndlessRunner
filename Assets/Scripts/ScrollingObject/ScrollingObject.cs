using UnityEngine;
using Game.Marker;
using System;

namespace Game.ScrollingObj
{
    public class ScrollingObject : MonoBehaviour
    {
        public event Action<ScrollingObject> OnResetZoneCollided;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float speed)
        {
            _rb.linearVelocity = Vector2.left * speed;
        }

        public void GoToInitialPos(Vector2 pos)
        {
            _rb.position = pos;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<ScrollResetZoneMarker>(out _))
            {
                OnResetZoneCollided?.Invoke(this);
            }
        }

    }
}


