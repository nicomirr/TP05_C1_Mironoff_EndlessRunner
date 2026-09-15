using UnityEngine;

namespace Game.Spawner
{
    public class FixedSpawnPositionProvider : MonoBehaviour, ISpawnPositionProvider
    {        
        public Vector2 GetSpawnPos()
        {
            return this.transform.position;
        }
    }
}


