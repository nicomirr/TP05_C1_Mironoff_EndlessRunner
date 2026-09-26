using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "StateMachineTransitionSo", menuName = "Scriptable Objects/StateMachineTransitionSo")]
    public class StateMachineTransitionSo : ScriptableObject
    {
        [SerializeField] private PlayerState _state;
        public PlayerState State => _state;

        [SerializeField] private List<PlayerState> _availableTransitions;
        public List<PlayerState> AvailableTransitions => _availableTransitions;
    }

}

