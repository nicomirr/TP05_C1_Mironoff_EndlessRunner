using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParallaxDataSo", menuName = "Scriptable Objects/ParallaxDataSo")]
    public class ParallaxDataSo : ScriptableObject
    {
        [SerializeField] private ParallaxType _parallaxType;
        public ParallaxType ParallaxType => _parallaxType;

        [SerializeField] private GameObject _background;
        public GameObject Background => _background; 

        [SerializeField] private SpeedModifierDataSo _speedModifierData;
        public SpeedModifierDataSo SpeedModifierData => _speedModifierData;

        [Tooltip("Controla el último valor de X antes de que se reinicie la posición del background")]
        [SerializeField] private float _minXPos;
        public float MinXPos => _minXPos;

        [Tooltip("0 frena el parallax")]
        [Range(0,1)] [SerializeField] private int _worldStoppedSpeedModifier;
        public int WorldStoppedSpeedModifier => _worldStoppedSpeedModifier;

    }
}


