using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly DataProvider _data;
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;

        public GameplayState(DataProvider data, GameplayEcs ecs, IGameLoop gameLoop)
        {
            _data = data;
            _ecs = ecs;
            _gameLoop = gameLoop;
        }

        //private bool a = false;

        public void Enter()
        {
            _ecs.BasicSystems.Start();
            _ecs.BirdSystems.Start();
            _ecs.PipesSystems.Start();

            //
            _ecs.PreGameOverSystems.Start();
        }

        public void Exit()
        {
            _ecs.BasicSystems.Stop();
            _ecs.BirdSystems.Stop();
            _ecs.PipesSystems.Stop();
            //_ecs.GameOverSystems.Start();
        }
    }
}