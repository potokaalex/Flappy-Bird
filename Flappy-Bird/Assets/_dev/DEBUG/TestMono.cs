using System.Collections.Generic;
using UnityEngine;
using System;

public class TestMono : MonoBehaviour
{
    private void Start()
    {

    }

    public void FixedUpdate()
    {

    }

    private void OnDestroy()
    {

    }
}

public interface IStateFactory
{
    public StateType Create<StateType>() where StateType : IState;
}

public class StateFactory : IStateFactory
{
    //private IInstantiator _instantiator;

    //public StateFactory(IInstantiator instantiator)
    //    => _instantiator = instantiator;

    public StateType Create<StateType>() where StateType : IState
        => default;
        //=> _instantiator.Instantiate<StateType>();
}

public class StateMachine
{
    private Dictionary<Type, IState> _states = new();
    private IStateFactory _factory;
    private IState _currentState;

    public StateMachine(IStateFactory factory)
        => _factory = factory;

    public void SwitchTo<StateType>() where StateType : IState
    {
        _currentState?.Exit();
        _currentState = GetState<StateType>();
        _currentState.Enter();
    }

    private IState GetState<StateType>() where StateType : IState
    {
        var stateType = typeof(StateType);

        if (!_states.ContainsKey(stateType))
            _states.Add(stateType, _factory.Create<StateType>());

        return _states[stateType];
    }
}

public interface IState
{
    public void Enter() { }

    public void Exit() { }
}

//Может стоит отступить от Bird-entity.
//Хотелось бы разделять всё на НЕЗАВИСИМЫЕ фичи...
//Bird - не фича...

//
//