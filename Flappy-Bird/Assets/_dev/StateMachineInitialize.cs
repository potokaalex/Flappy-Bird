using FlappyBird.Infrastructure;
using FlappyBird;
using Zenject;

public class StateMachineInitialize : IInitializable
{
    private readonly IStateMachine _stateMachine;
    private readonly IStateFactory _stateFactory;

    public StateMachineInitialize(IStateMachine stateMachine, IStateFactory stateFactory)
    {
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }

    public void Initialize()
    {
        _stateMachine.Initialize(
            _stateFactory.Create<LevelState>(),
            _stateFactory.Create<LoadingState>());
    }
}