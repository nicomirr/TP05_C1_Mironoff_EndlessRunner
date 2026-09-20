using System;
using System.Collections.Generic;

namespace Game.Events
{
    public static class AudioEvents
    {
        public static event Action OnInitializeVolumeRequest;
        public static event Action<Dictionary<string, float>> OnInitializeVolume;
        public static event Action<List<string>, float> OnVolumeChanged;

        public static void RaiseInitializeVolumeRequest()
        {
            OnInitializeVolumeRequest?.Invoke();
        }

        public static void RaiseInitializeVolume(Dictionary<string, float> volumes)
        {
            OnInitializeVolume?.Invoke(volumes);
        }
      
        public static void RaiseVolumeChanged(List<string> groups, float volume)
        {
            OnVolumeChanged?.Invoke(groups, volume);
        }
    }
}

