using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LoadLevelButton : ButtonBase
    {
        private IStateMachine _stateMachine;

        [Inject]
        public void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private protected override void OnClick()
            => _stateMachine.SwitchTo<LevelLoadingState>();
    }
}