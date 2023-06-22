using FlappyBird.Gameplay;
using FlappyBird.Gameplay.Core.Score;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly IPlayerProgress _playerProgress;
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;
        private readonly ScoreProgressWriter _scoreProgressWriter;

        public GameplayState(GameplayEcs ecs, IDataProvider dataProvider, IPlayerProgress playerProgress,
            IGameLoop gameLoop)
        {
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;
            _ecs = ecs;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {

            _ecs.CoreSystems.Start(_gameLoop);
        }

        public void Exit()
        {

            _ecs.CoreSystems.Stop(_gameLoop);
        }
    }
}