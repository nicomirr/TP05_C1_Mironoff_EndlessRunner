using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;
using Game.Events;
using System.Collections.ObjectModel;

namespace Game.Parallax
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private ParallaxManagerDataSo _data;

        [SerializeField] private Transform _parent;

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;
        private ISpeedProvider _worldSpeedProvider;

        private readonly Dictionary<BiomeType, List<ParallaxDataSo>> _biomes = new();
        private readonly Dictionary<BiomeType, Color32> _biomeBackgroundColors = new();

        private readonly Dictionary<ParallaxType, ParallaxBackground> _backgrounds = new();

        private Camera _camera;
                
        private void Awake()
        {
            foreach (ParallaxBiomeDataSo biomeData in _data.BiomesConfig.Biomes)
            {
                _biomes.Add(biomeData.BiomeType, biomeData.ParallaxBackgroundsData);
                _biomeBackgroundColors.Add(biomeData.BiomeType, biomeData.BackgroundColor);
            }                       

            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;

            _camera = Camera.main;
        }

        private void OnEnable()
        {
            GameStateEvents.OnBiomeTypeBroadcast += ChangeBiome;
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
            GameStateEvents.OnBiomeTypeBroadcast -= ChangeBiome;
        }

        private void ChangeBiome(BiomeType biomeType)
        {
            foreach (KeyValuePair<ParallaxType, ParallaxBackground> background in _backgrounds)
            {
                background.Value.DisposeBackground();
            }

            foreach (ParallaxDataSo parallaxData in _biomes[biomeType])
            {
                ParallaxBackground parallaxBackground = new ParallaxBackground(parallaxData, _parent);
                _backgrounds[parallaxData.ParallaxType] = parallaxBackground;
            }

            _camera.backgroundColor = _biomeBackgroundColors[biomeType];
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