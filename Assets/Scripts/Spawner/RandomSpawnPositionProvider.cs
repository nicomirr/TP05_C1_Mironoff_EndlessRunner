using UnityEngine;

namespace Game.Spawner
{
    public class RandomSpawnPositionProvider : MonoBehaviour, ISpawnPositionProvider
    {
        private Bounds _spawnerBounds;

        private void Awake()
        {
            _spawnerBounds = this.gameObject.GetComponent<Collider2D>().bounds;
        }

        public Vector2 GetSpawnPos()
        {
            float randomX = Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x);
            float randomY = Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y);

            return new Vector2(randomX, randomY);
        }
    }
}

