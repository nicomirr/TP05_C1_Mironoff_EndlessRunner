using UnityEngine;

namespace Game.Spawnable
{
    public class SpriteRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 90f;

        private void Update()
        {
            transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
        }
    }

}
