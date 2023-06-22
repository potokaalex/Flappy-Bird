using FlappyBird.Gameplay.Core.Score;
using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PreGameplayState : IState
    {
        private readonly IPlayerProgress _playerProgress;
        private readonly IDataProvider _dataProvider;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public PreGameplayState(GameplayEcs ecs, IGameLoop gameLoop, IDataProvider dataProvider,
            IPlayerProgress playerProgress)
        {
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;
            _gameLoop = gameLoop;
            _ecs = ecs;
        }

        public void Enter()
        {
            _playerProgress.RegisterWriter(new ScoreProgressWriter(_ecs.Contexts));
            _playerProgress.RegisterWriter(new OpenSkinsAmountProgressWriter());
            _playerProgress.LoadData();

            _dataProvider.Get<LevelSceneData>().GameOverUI
                .Initialize(_dataProvider.Get<ProgressData>().BirdOpenSkinsAmount);

            _ecs.Initialize();

            _ecs.PreGameplaySystems.Start(_gameLoop);
        }

        public void Exit()
        {
            _dataProvider.Get<LevelSceneData>().GameplayUI.PlayOpenAnimation();

            _ecs.PreGameplaySystems.Stop(_gameLoop);
        }
    }
}