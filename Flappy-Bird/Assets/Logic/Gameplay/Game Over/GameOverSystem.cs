using System.Collections.Generic;
using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverSystem : ReactiveSystem<InputEntity>
    {
        private readonly BreakableSystems _systems;
        private readonly SceneLoadingConfiguration _loadingConfig;
        private readonly IStateMachine _stateMachine;

        public GameOverSystem(
            InputContext context,
            BreakableSystems systems,
            SceneLoadingConfiguration loadingConfig,
            IStateMachine stateMachine)
            : base(context)
        {
            _systems = systems;
            _loadingConfig = loadingConfig;
            _stateMachine = stateMachine;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.GameOver.Added());

        protected override bool Filter(InputEntity entity)
            => true;

        protected override void Execute(List<InputEntity> entities)
        {
            _systems.IsBreak = true;
            _stateMachine.SwitchTo(typeof(LoadingState), _loadingConfig);
        }
    }
}