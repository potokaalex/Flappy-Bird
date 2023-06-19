using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PreGameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameplayEcs _ecs;
        private readonly IPlayerProgress _playerProgress;

        public PreGameplayState(GameplayEcs ecs,IPlayerProgress playerProgress, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _ecs = ecs;
            _playerProgress = playerProgress;
        }

        public void Enter()
        {
            _ecs.CreateSystems(); //To level loading state.

            _ecs.CoreSystems.Initialize(); //создание сущностей !
            _ecs.PreGameplaySystems.Initialize();

            _ecs.PreGameplaySystems.Start();
        }

        public void Exit()
        {
            _dataProvider.Get<GameOverStateConfiguration>().GameplayUI.PlayOpenAnimation();
            _ecs.PreGameplaySystems.Stop();
        }
    }
}