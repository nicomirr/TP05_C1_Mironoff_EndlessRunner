using UnityEngine;
using System.Collections.Generic;
using Game.Data;


namespace Game.Parallax
{
    public class ParallaxBackground
    {
        private ParallaxDataSo _data;

        private readonly float _effectiveWidth;

        private float _worldStoppedSpeedModifier;

        private List<Transform> _backgrounds = new();

        private GameObject _background;

        public ParallaxBackground(ParallaxDataSo data, Transform parent)
        {
            _data = data;

            _background = Object.Instantiate(_data.Background, parent);

            foreach (Transform child in _background.transform)
            {
                _backgrounds.Add(child);
            }

            SpriteRenderer spriteRenderer = _backgrounds[0].GetComponent<SpriteRenderer>();

            float backgroundWidth = spriteRenderer.bounds.size.x;

            _effectiveWidth = backgroundWidth - 0.01f;

            for (int i = 1; i < _backgrounds.Count; i++)
            {
                Vector3 position = _backgrounds[0].position;

                position.x += _effectiveWidth * i;

                _backgrounds[i].position = position;
            }

            _worldStoppedSpeedModifier = 1;
        }

        public void MoveBackgrounds(float speed)
        {
            foreach (Transform background in _backgrounds)
            {
                background.position += Vector3.left * (speed *
                    _data.SpeedModifierData.SpeedModifier * Time.deltaTime * _worldStoppedSpeedModifier);
            }
        }

        public void RepositionBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                if (background.position.x <= _data.MinXPos)
                {
                    Vector3 position = background.position;

                    position.x += _effectiveWidth * _backgrounds.Count;

                    background.position = position;
                }
            }
        }
        
        public void DisposeBackground()
        {
            Object.Destroy(_background);
        }

        public void StopParallax()
        {
            _worldStoppedSpeedModifier = _data.WorldStoppedSpeedModifier;
        }
    }
}