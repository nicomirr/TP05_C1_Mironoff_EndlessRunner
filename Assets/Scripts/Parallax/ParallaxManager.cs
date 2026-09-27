using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;
using Game.Events;

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
        private readonly List<ParallaxBackground> _markedForDisposalBackgrounds = new();

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
            UpdateBackgrounds();
            UpdateMarkedForDisposalBackgrounds();
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopParallax;
            GameStateEvents.OnBiomeTypeBroadcast -= ChangeBiome;
        }

        private void UpdateBackgrounds()
        {
            foreach (KeyValuePair<ParallaxType, ParallaxBackground> background in _backgrounds)
            {
                background.Value.MoveBackgrounds(_worldSpeedProvider.WorldCurrentSpeed);
                background.Value.RepositionBackgrounds();
            }
        }

        private void UpdateMarkedForDisposalBackgrounds()
        {
            foreach (ParallaxBackground background in _markedForDisposalBackgrounds)
            {
                background.MoveBackgrounds(_worldSpeedProvider.WorldCurrentSpeed);
                background.RepositionBackgrounds();
            }
        }

        private void ChangeBiome(BiomeType biomeType)
        {
            foreach (KeyValuePair<ParallaxType, ParallaxBackground> background in _backgrounds)
            {
                background.Value.MarkForDisposal();
                _markedForDisposalBackgrounds.Add(background.Value);
            }

            foreach (ParallaxDataSo parallaxData in _biomes[biomeType])
            {
                ParallaxBackground parallaxBackground = new ParallaxBackground(parallaxData, _parent);
                
                if(_markedForDisposalBackgrounds.Count != 0)
                    parallaxBackground.SendToBack(_backgrounds[parallaxData.ParallaxType]);

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