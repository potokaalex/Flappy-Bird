using System.Collections.Generic;
using FlappyBird.StateMachine;
using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverSystem : ReactiveSystem<LevelEntity>
    {
        private BreakableSystems _systems;
        private SceneLoadingConfiguration _loadingConfig;
        private IStateMachine _stateMachine;

        public GameOverSystem(
            LevelContext context, 
            BreakableSystems systems, 
            SceneLoadingConfiguration loadingConfig, 
            IStateMachine stateMachine)
            : base(context)
        {
            _systems = systems;
            _loadingConfig = loadingConfig;
            _stateMachine = stateMachine;
        }

        protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
            => context.CreateCollector(LevelMatcher.AllOf(LevelMatcher.GameOver).Added());

        protected override bool Filter(LevelEntity entity)
            => true;

        protected override void Execute(List<LevelEntity> entities)
        {
            foreach (var entity in entities)
                entity.isGameOver = false;

            _systems.IsBreak = true;

            _stateMachine.SwitchTo(typeof(LoadingState), _loadingConfig);
        }
    }
}
