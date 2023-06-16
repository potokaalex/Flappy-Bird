using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;

        public GameplayState(IDataProvider dataProvider, GameplayEcs ecs, IGameLoop gameLoop)
        {
            _dataProvider = dataProvider;
            _ecs = ecs;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {
            _ecs.CoreSystems.Start();
        }

        public void Exit()
        {
            _ecs.CoreSystems.Stop();
        }
    }
}