using System;

namespace Game.Events
{
    public class ScoreEvents
    {
        public static event Action<float> OnPlayerScoreUpdated;
        
        public static void RaisePlayerScoreUpdated(float score)
        {
            OnPlayerScoreUpdated?.Invoke(score);
        }
    }

}
