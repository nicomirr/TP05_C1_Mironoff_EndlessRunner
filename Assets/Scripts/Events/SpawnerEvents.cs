using System;

namespace Game.Events
{
    public static class SpawnerEvents
    {
        public static event Action OnStopSpawners;

        public static void RaiseStopSpawners()
        {
            OnStopSpawners?.Invoke();
        }
    }
}

