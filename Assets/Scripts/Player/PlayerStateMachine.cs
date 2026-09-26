using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.Player
{
    public class PlayerStateMachine : IPlayerStateChanger, IPlayerStateReader
    {
        private PlayerState _currentState;
        public PlayerState CurrentState => _currentState;

        private readonly Dictionary<PlayerState, HashSet<PlayerState>> _stateTransitions = new();    

        public PlayerStateMachine(PlayerConfigSo data)
        {
            foreach(StateMachineTransitionSo stateInfo in data.FsmTransitionsData.StateTransitions)
            {
                PlayerState key = stateInfo.State;

                HashSet<PlayerState> stateTransitions = new(stateInfo.AvailableTransitions);
                               
                _stateTransitions.Add(key, stateTransitions);
            }

            _currentState = PlayerState.Normal;
        }

        
        bool IPlayerStateChanger.TryChangeState(PlayerState newState)
        {
            HashSet<PlayerState> availableStates = _stateTransitions[_currentState];

            if (!availableStates.Contains(newState)) return false;

            _currentState = newState;
            return true;
        }
    }
}
