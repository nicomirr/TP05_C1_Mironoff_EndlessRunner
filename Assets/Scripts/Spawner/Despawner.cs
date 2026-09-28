using UnityEngine;

namespace Game.Spawner
{
    public class Despawner : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }

}

