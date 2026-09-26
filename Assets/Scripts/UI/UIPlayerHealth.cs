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

            PlayerEvents.OnPlayerHealed += AddHearth;
            PlayerEvents.OnPlayerDamaged += RemoveHearth;
        }

        private void OnDisable()
        {
            UIEvents.OnInitializePlayerUIHealth -= InitializePlayerHearths;

            PlayerEvents.OnPlayerHealed -= AddHearth;
            PlayerEvents.OnPlayerDamaged -= RemoveHearth;
        }

        private void InitializePlayerHearths(int totalHearts)
        {            
            for (int i = 0; i < totalHearts; i++)
            {
                _playerHearts.Add(Instantiate(_data.HeartPrefab, this.transform));
                _playerHearts[i].SetActive(false);
            }

            _playerHearts[0].SetActive(true);

            
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

        private void AddHearth()
        {
            foreach (GameObject heart in _playerHearts)
            {
                if (!heart.activeSelf)
                {
                    heart.SetActive(true);
                    return;
                }
            }
        }
    }

}
