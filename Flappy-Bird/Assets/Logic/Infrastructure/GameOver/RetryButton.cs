namespace FlappyBird.Infrastructure
{
    public class RetryButton : ButtonBase
    {
        private IStateMachine _stateMachine;
        private DataProvider _data;

        public void Initialize(DataProvider data, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = data;
        }

        private protected override void OnClick()
            => _stateMachine.SwitchTo<SceneLoadingState, SceneLoadingConfiguration>(_data.LevelLoadingConfig);
    }
}