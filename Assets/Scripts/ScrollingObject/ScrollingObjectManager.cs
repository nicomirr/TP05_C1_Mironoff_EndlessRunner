using UnityEngine;
using System.Collections.Generic;

namespace Game.ScrollingObj
{
    public class ScrollingObjectManager : MonoBehaviour
    {
        [SerializeField] private Transform _initialPos;
        [SerializeField] private List<ScrollingObject> _scrollingObjects;

        private void OnEnable()
        {
            foreach (ScrollingObject obj in _scrollingObjects)
                obj.OnResetZoneCollided += SendObjectToStartingPos;
        }

        private void FixedUpdate()
        {
            foreach (ScrollingObject obj in _scrollingObjects)
            {
                obj.Move(.3f);
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


