using Game.Data;
using Game.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Environment
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private ParallaxDataSo _data;

        [SerializeField] private List<Transform> _backgrounds = new();

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;

        private ISpeedProvider _worldSpeedProvider;

        private float _backgroundWidth;

        private float _worldStoppedSpeedModifier;

        private void Awake()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;

            SpriteRenderer spriteRenderer = _backgrounds[0].GetComponent<SpriteRenderer>();

            _backgroundWidth = spriteRenderer.bounds.size.x;

            for (int i = 1; i < _backgrounds.Count; i++)
            {
                Vector3 position = _backgrounds[0].position;
                position.x += _backgroundWidth * i;

                _backgrounds[i].position = position;
            }
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDeath += StopParallax;
        }

        private void Start()
        {
            _worldStoppedSpeedModifier = 1;
        }

        private void Update()
        {
            MoveBackgrounds();
            RepositionBackgrounds();
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDeath -= StopParallax;
        }

        private void StopParallax()
        {
            _worldStoppedSpeedModifier = _data.WorldStoppedSpeedModifier;
        }

        private void MoveBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                background.position += Vector3.left * (_worldSpeedProvider.WorldCurrentSpeed * 
                    _data.SpeedModifierData.SpeedModifier * Time.deltaTime * _worldStoppedSpeedModifier);
            }
        }

        private void RepositionBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                if (background.position.x <= _data.MinXPos)
                {
                    Vector3 position = background.position;

                    position.x += _backgroundWidth * _backgrounds.Count;

                    background.position = position;
                }
            }
        }
    }
}