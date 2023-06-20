using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LoadMenuButton : ButtonBase
    {
        private IStateMachine _stateMachine;

        [Inject]
        public void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private protected override void OnClick()
            => _stateMachine.SwitchTo<MenuLoadingState>();
    }
}