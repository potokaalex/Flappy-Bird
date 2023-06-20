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
            if (_stateMachine.GetCurrentState().GetType() != typeof(GameplayState) &&
                _stateMachine.GetCurrentState().GetType() != typeof(PauseState))
                return;

            if (_isPause)
                GameplayResume();
            else
                GameplayPause();
        }

        private void GameplayPause()
        {
            _isPause = true;

            _buttonImage.sprite = _resumeSprite;
            _stateMachine.SwitchTo<PauseState>();
        }

        private void GameplayResume()
        {
            _isPause = false;

            _buttonImage.sprite = _pauseSprite;
            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}