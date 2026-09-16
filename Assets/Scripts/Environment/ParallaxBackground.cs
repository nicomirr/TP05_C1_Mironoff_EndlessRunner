using Game.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Environment
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private ParallaxDataSo _data;
        [SerializeField] private List<Transform> _backgrounds = new();

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;

        [SerializeField] private float _seamOverlap = 1f / 64f;

        private ISpeedProvider _worldSpeedProvider;

        private void Awake()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;

            CompressTilemapBounds();
            PositionBackgrounds();
        }

        private void Update()
        {
            MoveBackgrounds();
            RepositionBackgrounds();
        }

        private void CompressTilemapBounds()
        {
            foreach (Transform background in _backgrounds)
            {
                Tilemap tilemap = background.GetComponentInChildren<Tilemap>();
                tilemap.CompressBounds();
            }
        }

        private void PositionBackgrounds()
        {
            for (int i = 1; i < _backgrounds.Count; i++)
            {
                Tilemap previousTilemap =
                    _backgrounds[i - 1].GetComponentInChildren<Tilemap>();

                Tilemap currentTilemap =
                    _backgrounds[i].GetComponentInChildren<Tilemap>();

                float previousRightEdge = GetRightEdge(previousTilemap);
                float currentLeftEdge = GetLeftEdge(currentTilemap);

                float difference =
                    previousRightEdge - currentLeftEdge - _seamOverlap;

                _backgrounds[i].position += Vector3.right * difference;
            }
        }

        private float GetLeftEdge(Tilemap tilemap)
        {
            BoundsInt bounds = tilemap.cellBounds;

            return tilemap.CellToWorld(
                new Vector3Int(bounds.xMin, bounds.yMin, 0)).x;
        }

        private float GetRightEdge(Tilemap tilemap)
        {
            BoundsInt bounds = tilemap.cellBounds;

            return tilemap.CellToWorld(
                new Vector3Int(bounds.xMax, bounds.yMin, 0)).x;
        }

        private void MoveBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                background.position += Vector3.left *
                    (_worldSpeedProvider.WorldCurrentSpeed *
                     _data.SpeedModifierData.SpeedModifier *
                     Time.deltaTime);
            }
        }

        private void RepositionBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                if (background.position.x > _data.MinXPos)
                    continue;

                Transform rightmostBackground = GetRightmostBackground(background);

                Tilemap currentTilemap =
                    background.GetComponentInChildren<Tilemap>();

                Tilemap rightmostTilemap =
                    rightmostBackground.GetComponentInChildren<Tilemap>();

                float currentLeftEdge = GetLeftEdge(currentTilemap);
                float rightmostRightEdge = GetRightEdge(rightmostTilemap);

                float difference =
                    rightmostRightEdge - currentLeftEdge - _seamOverlap;

                background.position += Vector3.right * difference;
            }
        }

        private Transform GetRightmostBackground(Transform excludedBackground)
        {
            Transform rightmost = null;

            foreach (Transform background in _backgrounds)
            {
                if (background == excludedBackground)
                    continue;

                if (rightmost == null ||
                    GetRightEdge(background.GetComponentInChildren<Tilemap>()) >
                    GetRightEdge(rightmost.GetComponentInChildren<Tilemap>()))
                {
                    rightmost = background;
                }
            }

            return rightmost;
        }
    }
}