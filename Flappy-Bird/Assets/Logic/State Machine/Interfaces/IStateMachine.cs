using System;

namespace FlappyBird.StateMachine
{
    public interface IStateMachine
    {
        public void Initialize(params IState[] states);

        public void SwitchTo<StateType>() where StateType : IState;

        public void SwitchTo<ParameterType>(Type stateType, ParameterType parameter)
            where ParameterType : IStateParameter;
    }
}