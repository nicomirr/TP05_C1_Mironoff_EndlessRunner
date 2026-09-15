using UnityEngine;

namespace Game.Spawner
{
    public interface ISpawnPositionProvider
    {
        public Vector2 GetSpawnPos();
    }
}

