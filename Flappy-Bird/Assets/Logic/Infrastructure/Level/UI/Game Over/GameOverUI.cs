using FlappyBird.Gameplay.Core.Bird;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private BirdOnBoardUIAnimator _birdOnBoardUIAnimator;
        [SerializeField] private GameOverUIAnimator _gameOverUIAnimator;
        [SerializeField] private ScoreOnBoardUI _scoreOnBoardUI;

        private IDataProvider _dataProvider;
        private int _initialBirdOpenSkinsAmount;

        [Inject]
        private void Constructor(IDataProvider dataProvider)
            => _dataProvider = dataProvider;

        public void Initialize(int initialBirdOpenSkinsAmount)
            => _initialBirdOpenSkinsAmount = initialBirdOpenSkinsAmount;

        public void Show()
        {
            var progressData = _dataProvider.Get<ProgressData>();

            _gameOverUIAnimator.PlayOpenAnimation();
            _scoreOnBoardUI.ShowScore(progressData.CurrentScore, progressData.MaxScore);
            ShowBirdOnBoard(progressData);
        }

        private void ShowBirdOnBoard(ProgressData progressData)
        {
            var birdAppearance = _dataProvider.Get<BirdStaticData>().Appearance;

            if (progressData.BirdOpenSkinsAmount == _initialBirdOpenSkinsAmount)
                return;

            _gameOverUIAnimator.StartActionAfterCurrentAnimation(
                () => _birdOnBoardUIAnimator.PlayShowAnimation(
                    birdAppearance.GetSkin(progressData.BirdOpenSkinsAmount - 1)));
        }
    }
}