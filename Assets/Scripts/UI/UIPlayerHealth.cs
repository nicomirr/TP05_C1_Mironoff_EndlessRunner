using UnityEngine;
using System.Collections.Generic;
using Game.Events;
using Game.Data;

namespace Game.UI
{
    public class UIPlayerHealth : MonoBehaviour
    {
        [SerializeField] private HeartPrefabSo _data;

        private readonly List<GameObject> _playerHearts = new();
               
        private void OnEnable()
        {
            UIEvents.OnInitializePlayerUIHealth += InitializePlayerHearths;
            PlayerEvents.OnPlayerDamaged += RemoveHearth;
        }

        private void OnDisable()
        {
            UIEvents.OnInitializePlayerUIHealth -= InitializePlayerHearths;
            PlayerEvents.OnPlayerDamaged -= RemoveHearth;
        }

        private void InitializePlayerHearths(int totalHearts)
        {            
            for (int i = 0; i < totalHearts; i++)
            {
                _playerHearts.Add(Instantiate(_data.HeartPrefab, this.transform));
            }
        }  
        
        private void RemoveHearth()
        {
            foreach(GameObject heart in _playerHearts)
            {
                if(heart.activeSelf)
                {
                    heart.SetActive(false);
                    return;
                }
            }
        }
    }

}
