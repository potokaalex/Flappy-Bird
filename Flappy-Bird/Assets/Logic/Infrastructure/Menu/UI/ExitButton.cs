using Zenject;

namespace FlappyBird.Infrastructure
{
    public class ExitButton : ButtonBase
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private protected override void OnClick()
            => _stateMachine.SwitchTo<ExitState>();
    }
}