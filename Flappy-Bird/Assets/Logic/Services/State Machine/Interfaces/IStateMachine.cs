using System;

namespace FlappyBird
{
    public interface IStateMachine
    {
        public void Initialize(params IState[] states);

        public void SwitchTo<StateType>()
            where StateType : IState;
        
        public void SwitchTo<StateType, ParameterType>(ParameterType parameter)
            where StateType : IState<ParameterType>
            where ParameterType : IStateParameter;
    }
}