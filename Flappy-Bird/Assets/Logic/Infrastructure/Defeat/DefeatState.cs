namespace FlappyBird.Infrastructure
{
    public class DefeatState : IState
    {
        private readonly DataProvider _data;
        private readonly IStateMachine _stateMachine;

        public DefeatState(DataProvider data, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = data;
        }

        public void Enter()
        {
            _data.Ecs.DefeatSystems.Initialize();
            //animations

            _stateMachine.SwitchTo<LoadingState, SceneLoadingConfiguration>(_data.LevelLoadingConfig);
        }

        public void Exit()
        {
            _data.Ecs.DefeatSystems.Dispose();
            _data.Ecs.Reset();
        }
    }
}