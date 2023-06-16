using FlappyBird.Gameplay;
using FlappyBird.Infrastructure;

namespace FlappyBird
{
    public class PreGameOverState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameplayEcs _ecs;

        public PreGameOverState(IDataProvider dataProvider, GameplayEcs ecs)
        {
            _dataProvider = dataProvider;
            _ecs = ecs;
        }

        public void Enter()
        {
            _ecs.PreGameOverSystems.Initialize();
            _ecs.PreGameOverSystems.Start();

            _dataProvider.Get<GameOverStateConfiguration>().GameplayUI.PlayCloseAnimation();
        }

        public void Exit()
        {
            _ecs.PreGameOverSystems.Stop();
        }
    }
}