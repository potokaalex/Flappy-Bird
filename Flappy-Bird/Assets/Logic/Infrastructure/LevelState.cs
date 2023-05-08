using FlappyBird.StateMachine;
using FlappyBird.Infrastructure;

public class LevelState : IState
{
    private LevelEcs _levelEcs;
    private IStateMachine _stateMachine;

    public LevelState(GameLoop gameLoop, DataProvider dataProvider, IStateMachine stateMachine)
    {
        _levelEcs = new LevelEcs(gameLoop, dataProvider, stateMachine);
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        //input enable !
        //загрузка данных !

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
