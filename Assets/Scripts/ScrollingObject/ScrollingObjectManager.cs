using UnityEngine;
using System.Collections.Generic;

namespace Game.ScrollingObj
{
    public class ScrollingObjectManager : MonoBehaviour
    {
        [SerializeField] private List<ScrollingObject> _scrollingObjects;
        [SerializeField] private Transform _initialPos;

        [SerializeField] private MonoBehaviour _worldSpeedProviderMonobehaviour;
        private ISpeedProvider _worldSpeedProvider;

        private void OnEnable()
        {
            _worldSpeedProvider = _worldSpeedProviderMonobehaviour as ISpeedProvider;

            foreach (ScrollingObject obj in _scrollingObjects)
                obj.OnResetZoneCollided += SendObjectToStartingPos;
        }

        private void FixedUpdate()
        {
            foreach (ScrollingObject obj in _scrollingObjects)
            {
                obj.Move(_worldSpeedProvider.WorldCurrentSpeed);
            }
        }

        private void OnDisable()
        {
            foreach (ScrollingObject obj in _scrollingObjects)
                obj.OnResetZoneCollided -= SendObjectToStartingPos;
        }

        private void SendObjectToStartingPos(ScrollingObject obj)
        {
            obj.GoToInitialPos(new Vector2(_initialPos.position.x, obj.transform.position.y));
        }        
    }
}


