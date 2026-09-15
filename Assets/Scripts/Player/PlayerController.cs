using Game.Data;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _playerConfig;

        private PlayerInputs _playerInputs;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
        }

    }
}

