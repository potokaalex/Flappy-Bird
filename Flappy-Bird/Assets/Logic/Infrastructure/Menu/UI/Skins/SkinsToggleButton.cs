using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class SkinsToggleButton : ButtonBase
    {
        [SerializeField] private BirdSkinsBoardUI _birdSkinsBoard;

        private bool _isOpened;

        private protected override void OnClick()
        {
            _isOpened = !_isOpened;

            if (_isOpened)
                _birdSkinsBoard.Animator.PlayShowAnimation();
            else
                _birdSkinsBoard.Animator.PlayHideAnimation();
        }
    }
}