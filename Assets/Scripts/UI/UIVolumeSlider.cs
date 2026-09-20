using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIVolumeSlider : MonoBehaviour
    {
        [SerializeField] private SliderTypeSo _data;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnVolumeChanged);

            AudioEvents.OnInitializeVolume += InitializeSliderValue;
        }

        private void Start()
        {
            AudioEvents.RaiseInitializeVolumeRequest();
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveAllListeners();
            AudioEvents.OnInitializeVolume -= InitializeSliderValue;
        }

        private void InitializeSliderValue(Dictionary<string, float> volumes)
        {           
            foreach(KeyValuePair<string, float> pair in volumes)
            {
                if(_data.VolumeTypes.Contains(pair.Key))
                {
                    _slider.value = pair.Value;
                    break;
                }
            }
        }

        private void OnVolumeChanged(float volume)
        {
            AudioEvents.RaiseVolumeChanged(_data.VolumeTypes, volume);
        }
    }
}

