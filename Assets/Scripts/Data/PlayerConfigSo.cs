using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PlayerConfigSo", menuName = "Scriptable Objects/PlayerConfigSo")]
    public class PlayerConfigSo : ScriptableObject
    {
        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;
    }

}

