namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState<GameplayStateConfiguration>
    {
        private readonly DataProvider _data;

        public GameplayState(DataProvider data)
            => _data = data;

        public void Enter(GameplayStateConfiguration config)
        {
            _data.BirdConfiguration.Initialize(config.BirdSpawnPoint.position);

            _data.Ecs.CreateEntities();
            _data.Ecs.GameplaySystems.Initialize();
        }

        public void Exit()
        {
            _data.Ecs.GameplaySystems.Dispose();
        }
    }
}