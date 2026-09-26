using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "StateMachineTransitionsSo", menuName = "Scriptable Objects/StateMachineTransitionsSo")]
    public class StateMachineTransitionsConfigSo : ScriptableObject
    {
        [SerializeField] private List<StateMachineTransitionSo> _stateTransitions;
        public List<StateMachineTransitionSo> StateTransitions => _stateTransitions;
    }

}

