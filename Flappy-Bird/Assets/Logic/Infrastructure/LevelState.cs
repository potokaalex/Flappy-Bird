using FlappyBird.StateMachine;
using FlappyBird.Infrastructure;

public class LevelState : IState<LevelConfiguration>
{
    private LevelEcs _levelEcs;
    private IStateMachine _stateMachine;
    private DataProvider _dataProvider;

    public LevelState(GameLoop gameLoop, DataProvider dataProvider, IStateMachine stateMachine)
    {
        _levelEcs = new LevelEcs(gameLoop, dataProvider, stateMachine);
        _stateMachine = stateMachine;

        _dataProvider = dataProvider;
    }

    public void Enter(LevelConfiguration config)
    {
        _dataProvider.BirdConfiguration.Initialize(
            config.FlyUpAction, config.BirdPrefab, config.BirdSpawnPoint.position);

        _levelEcs.Initialize();
    }

    public void Exit()
    {
        _levelEcs.Cleanup();
    }
}

//Все стейты:
//menu (main etc.)
//loading
//level
//defeat
//pause
