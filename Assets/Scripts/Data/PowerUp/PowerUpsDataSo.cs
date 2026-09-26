using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "PoweUpsDataSo", menuName = "Scriptable Objects/PoweUpsDataSo")]
    public class PowerUpsDataSo : ScriptableObject
    {
        [SerializeField] private InvincibilityPowDataSo _invisibilityPowData;
        public InvincibilityPowDataSo InvincibilityDataSo => _invisibilityPowData;

        [SerializeField] private PowDataSo _healthPowData;
        public PowDataSo HealthPowData => _healthPowData;
       
    }

}

