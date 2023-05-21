﻿using Zenject;

namespace FlappyBird
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator)
            => _instantiator = instantiator;

        public StateType Create<StateType>() where StateType : IState
            => _instantiator.Instantiate<StateType>();

        public StateType Create<StateType>(bool a) where StateType : IState<IStateParameter>
            => _instantiator.Instantiate<StateType>();
    }
}