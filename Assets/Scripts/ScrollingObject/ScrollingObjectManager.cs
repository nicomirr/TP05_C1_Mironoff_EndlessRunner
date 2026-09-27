using UnityEngine;
using System.Collections.Generic;

namespace Game.ScrollingObj
{
    public class ScrollingObjectManager : MonoBehaviour
    {
        [SerializeField] private List<ScrollingObject> _scrollingObjects;
        [SerializeField] private Transform _initialPos;


        private void OnEnable()
        {
            foreach (ScrollingObject scrollingObject in _scrollingObjects)
                scrollingObject.OnResetZoneCollided += SendObjectToStartingPos;
        }

        private void FixedUpdate()
        {
            foreach (ScrollingObject scrollingObject in _scrollingObjects)
            {
                scrollingObject.Move();
            }
        }

        private void OnDisable()
        {
            foreach (ScrollingObject scrollingObject in _scrollingObjects)
                scrollingObject.OnResetZoneCollided -= SendObjectToStartingPos;
        }

        private void SendObjectToStartingPos(ScrollingObject scrollingObject)
        {
            scrollingObject.GoToInitialPos(new Vector2(_initialPos.position.x, scrollingObject.transform.position.y));
        }        
    }
}


