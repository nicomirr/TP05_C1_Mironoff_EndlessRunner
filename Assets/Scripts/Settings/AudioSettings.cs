using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Events;

namespace Game.Settings
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioGroupsSo _data;

        private static AudioSettings _instance;

        private Dictionary<string, float> _volumes;     

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            _volumes = new Dictionary<string, float>();

            foreach(string group in _data.AudioGroups)
            {
                _volumes.Add(group, 1f);
            }

            AudioEvents.OnInitializeVolumeRequest += InitializeVolume;
            AudioEvents.OnVolumeChanged += ChangeVolume;
        }

        private void OnDestroy()
        {
            AudioEvents.OnInitializeVolumeRequest -= InitializeVolume;
            AudioEvents.OnVolumeChanged -= ChangeVolume;
        }

        private void InitializeVolume()
        {
            AudioEvents.RaiseInitializeVolume(_volumes);
        }

        private void ChangeVolume(List<string> groups, float volume)
        {
            foreach (string group in groups)
            {
                _volumes[group] = volume;
            }
        }
    }
}


