namespace FlappyBird.Infrastructure
{
    public class GameOverState : IState
    {
        private readonly DataProvider _data;
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;

        public GameOverState(DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _data = data;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {
            _data.GameOverStateConfiguration.GameplayUI.Hide();
            _data.GameOverStateConfiguration.GameOverUI.Show();

            _data.Ecs.DisposeSystems();
            _gameLoop.OnDispose += Dispose;
        }

        public void Exit()
        {
            //_data.Ecs.DefeatSystems.Dispose();
            //_data.Ecs.DestroyEntities();
        }

        private void Dispose()
        {
            _data.Ecs.DestroyAllEntities();
            _gameLoop.OnDispose -= Dispose;
        }
    }
}