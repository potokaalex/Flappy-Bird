using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;

        public GameplayState(GameplayEcs ecs, IGameLoop gameLoop)
        {
            _ecs = ecs;
            _gameLoop = gameLoop;
        }

        public void Enter() 
            => _ecs.CoreSystems.Start(_gameLoop);

        public void Exit() 
            => _ecs.CoreSystems.Stop(_gameLoop);
    }
}