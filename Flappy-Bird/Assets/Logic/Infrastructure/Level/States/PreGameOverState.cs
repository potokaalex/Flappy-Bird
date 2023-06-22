using FlappyBird.Infrastructure;
using FlappyBird.Gameplay;

namespace FlappyBird
{
    public class PreGameOverState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public PreGameOverState(IDataProvider dataProvider,IGameLoop gameLoop, GameplayEcs ecs)
        {
            _dataProvider = dataProvider;
            _gameLoop = gameLoop;
            _ecs = ecs;
        }

        public void Enter()
        {
            _dataProvider.Get<LevelSceneData>().GameplayUI.PlayCloseAnimation();

            _ecs.PreGameOverSystems.Start(_gameLoop);
        }

        public void Exit()
        {
            _ecs.PreGameOverSystems.Stop(_gameLoop);
        }
    }
}