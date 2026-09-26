using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Parallax
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private ParallaxManagerDataSo _data;

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;
        private ISpeedProvider _worldSpeedProvider;

        private readonly Dictionary<ParallaxType, ParallaxBackground> _backgrounds = new();

        private void Awake()
        {
            foreach(ParallaxDataSo parallaxData in _data.ParallaxBackgroundsData)
            {
                ParallaxBackground parallaxBackground = new ParallaxBackground(parallaxData);
           
                _backgrounds.Add(parallaxData.ParallaxType, parallaxBackground);
            }

            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopParallax;
        } 

        private void Update()
        {
            foreach (KeyValuePair<ParallaxType, ParallaxBackground> background in _backgrounds)
            {
                background.Value.MoveBackgrounds(_worldSpeedProvider.WorldCurrentSpeed);
                background.Value.RepositionBackgrounds();
            }
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopParallax;
        }

        private void StopParallax()
        {
            foreach (KeyValuePair<ParallaxType, ParallaxBackground> background in _backgrounds)
            {
                background.Value.StopParallax();
            }
        }
    }

}
