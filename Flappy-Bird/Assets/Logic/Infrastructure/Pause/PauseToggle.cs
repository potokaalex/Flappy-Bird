using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class PauseToggle : ButtonBase
    {
        [SerializeField] private Image _buttonImage;
        [SerializeField] private Sprite _pauseSprite;
        [SerializeField] private Sprite _resumeSprite;
        private IStateMachine _stateMachine;
        private bool _isPause;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private protected override void OnClick()
        {
            _isPause = !_isPause;

            if (_isPause)
                GameplayPause();
            else
                GameplayResume();
        }

        private void GameplayPause()
        {
            _buttonImage.sprite = _resumeSprite;

            _stateMachine.SwitchTo<PauseState>();
        }

        private void GameplayResume()
        {
            _buttonImage.sprite = _pauseSprite;

            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}