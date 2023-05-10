namespace FlappyBird.Infrastructure
{
    public class LevelState : IState<LevelStateConfiguration>
    {
        private LevelEcs _levelEcs;
        private DataProvider _dataProvider;

        public LevelState(IStateMachine stateMachine, IGameLoop gameLoop, DataProvider dataProvider)
        {
            _levelEcs = new LevelEcs(stateMachine, gameLoop, dataProvider);

            _dataProvider = dataProvider;
        }

        public void Enter(LevelStateConfiguration config)
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
}
