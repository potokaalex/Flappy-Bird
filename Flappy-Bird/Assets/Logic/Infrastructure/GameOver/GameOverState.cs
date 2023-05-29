namespace FlappyBird.Infrastructure
{
    public class GameOverState : IState
    {
        private readonly DataProvider _data;
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public GameOverState(DataProvider data,GameplayEcs ecs, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _data = data;
            _gameLoop = gameLoop;
            _ecs = ecs;
        }

        public void Enter()
        {
            //_data.GameOverStateConfiguration.GameplayUI.Hide();
            //_data.GameOverStateConfiguration.GameOverUI.Show();

            _ecs.Dispose();
        }

        public void Exit()
        {
            //_data.Ecs.DefeatSystems.Dispose();
            //_data.Ecs.DestroyEntities();
        }
    }
}