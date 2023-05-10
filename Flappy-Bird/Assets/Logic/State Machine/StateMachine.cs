using System.Collections.Generic;
using System;

namespace FlappyBird
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public void Initialize(params IState[] states)
        {
            _states = new(states.Length);

            foreach (var state in states)
                _states.Add(state.GetType(), state);
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(StateType)];
            _currentState.Enter();
        }

        public void SwitchTo<ParameterType>(Type stateType, ParameterType parameter)
            where ParameterType : IStateParameter
        {
            _currentState?.Exit();
            _currentState = _states[stateType];
            (_currentState as IState<ParameterType>).Enter(parameter);
        }
    }
}
