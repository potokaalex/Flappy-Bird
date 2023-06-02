using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameOverState : IState
    {
        private readonly DataProvider _data;
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;
        private readonly GameplayEcs _ecs;

        public GameOverState(DataProvider data, GameplayEcs ecs, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _data = data;
            _gameLoop = gameLoop;
            _ecs = ecs;
        }

        public void Enter()
        {
            var config = _data.PlayerProgress.GameOverStateConfiguration;

            config.GameplayUI.Hide();
            config.GameOverUI.Show();
        }

        public void Exit()
        {
            _ecs.Dispose();
        }
    }
}