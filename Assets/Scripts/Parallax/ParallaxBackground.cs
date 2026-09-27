using UnityEngine;
using System.Collections.Generic;
using Game.Data;

namespace Game.Parallax
{
    public class ParallaxBackground
    {
        private ParallaxDataSo _data;

        private readonly float _effectiveSingularWidth;

        private float _worldStoppedSpeedModifier;

        private List<Transform> _backgrounds = new();

        private GameObject _background;

        private bool _markedForDisposal;

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

            _effectiveSingularWidth = backgroundWidth - 0.01f;
            
            for (int i = 1; i < _backgrounds.Count; i++)
            {
                Vector3 position = _backgrounds[0].position;

                position.x += _effectiveSingularWidth * i;

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
            for (int i = _backgrounds.Count - 1; i >= 0; i--)
            {
                Transform background = _backgrounds[i];

                if (background.position.x <= _data.MinXPos)
                {
                    if (_markedForDisposal)
                    {
                        _backgrounds.RemoveAt(i);
                        Object.Destroy(background.gameObject);

                        if (_backgrounds.Count == 0)
                        {
                            Object.Destroy(_background);
                            return;
                        }

                        continue;
                    }

                    Vector3 position = background.position;

                    position.x += _effectiveSingularWidth * _backgrounds.Count;

                    background.position = position;
                }
            }
        }

        public void MarkForDisposal()
        {
            _markedForDisposal = true;
        }

        public void SendToBack(ParallaxBackground previousBackground)
        {
            float maxX = float.MinValue;

            foreach (Transform background in previousBackground._backgrounds)
            {
                if (background.position.x > maxX)
                    maxX = background.position.x;
            }

            float difference = maxX + _effectiveSingularWidth - _backgrounds[0].position.x;

            _background.transform.position += Vector3.right * difference;
        }

        public void StopParallax()
        {
            _worldStoppedSpeedModifier = _data.WorldStoppedSpeedModifier;
        }
    }
}