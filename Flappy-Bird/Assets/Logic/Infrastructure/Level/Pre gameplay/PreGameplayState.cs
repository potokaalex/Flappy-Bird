using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PreGameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public PreGameplayState(GameplayEcs ecs, IGameLoop gameLoop, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _gameLoop = gameLoop;
            _ecs = ecs;
        }

        public void Enter()
        {
            _ecs.Initialize();

            _ecs.PreGameplaySystems.Start(_gameLoop);
        }

        public void Exit()
        {
            _dataProvider.Get<UISceneData>().GameplayUI.PlayOpenAnimation();

            _ecs.PreGameplaySystems.Stop(_gameLoop);
        }
    }
}