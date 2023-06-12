using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly IDataProvider _data;
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;

        public GameplayState(IDataProvider data, GameplayEcs ecs, IGameLoop gameLoop)
        {
            _data = data;
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