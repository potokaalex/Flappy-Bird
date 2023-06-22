using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameOverState : IState
    {
        private readonly IDataProvider _data;
        private readonly IGameLoop _gameLoop;
        private readonly IPlayerProgress _playerProgress;
        private readonly GameplayEcs _ecs;

        public GameOverState(IDataProvider data, GameplayEcs ecs, IStateMachine stateMachine, IGameLoop gameLoop,
            IPlayerProgress playerProgress)
        {
            _data = data;
            _gameLoop = gameLoop;
            _playerProgress = playerProgress;
            _ecs = ecs;
        }

        public void Enter()
        {
            _playerProgress.SaveData();

            _data.Get<LevelSceneData>().GameOverUI.Show();
            
            _ecs.GameOverSystems.Start(_gameLoop);
        }

        public void Exit()
        {
            _playerProgress.UnregisterAllWriters();

            _ecs.Dispose();
        }
    }
}