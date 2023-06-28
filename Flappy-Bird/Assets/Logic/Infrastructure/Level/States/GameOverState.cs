using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameOverState : IState
    {
        private readonly IPlayerProgress _playerProgress;
        private readonly IDataProvider _dataProvider;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public GameOverState(GameplayEcs ecs, IGameLoop gameLoop, IDataProvider dataProvider,
            IPlayerProgress playerProgress)
        {
            _ecs = ecs;
            _gameLoop = gameLoop;
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;
        }

        public void Enter()
        {
            SaveProgress();

            _dataProvider.Get<LevelSceneData>().GameOverUI.Show();
            _ecs.GameOverSystems.Start(_gameLoop);
        }

        public void Exit()
            => _ecs.Dispose();

        private void SaveProgress()
        {
            var progressData = _dataProvider.Get<ProgressData>();

            UpdateOpenSkinsAmount(progressData);
            _playerProgress.SaveData(progressData);
        }

        private void UpdateOpenSkinsAmount(ProgressData data)
        {
            data.BirdOpenSkinsAmount = data.MaxScore switch
            {
                >= 10 => 3,
                >= 5 => 2,
                _ => 1
            };
        }
    }
}