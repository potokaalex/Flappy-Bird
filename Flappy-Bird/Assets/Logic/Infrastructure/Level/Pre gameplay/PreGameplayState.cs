using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PreGameplayState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameplayEcs _ecs;

        public PreGameplayState(GameplayEcs ecs, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _ecs = ecs;
        }

        public void Enter()
        {
            _ecs.Initialize(); //To level loading state.

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