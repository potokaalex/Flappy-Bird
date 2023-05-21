using System.Collections.Generic;
using FlappyBird.Infrastructure;
using Entitas;

namespace FlappyBird.Ecs.Basic.GameOver
{
    public class GameOverSystem : ReactiveSystem<InputEntity>
    {
        private readonly DefeatStateConfiguration _stateConfig;
        private readonly IStateMachine _stateMachine;

        public GameOverSystem(InputContext context, DefeatStateConfiguration stateConfig,
            IStateMachine stateMachine) : base(context)
        {
            _stateConfig = stateConfig;
            _stateMachine = stateMachine;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.GameOver.Added());

        protected override bool Filter(InputEntity entity)
            => true;

        protected override void Execute(List<InputEntity> entities)
            => _stateMachine.SwitchTo<DefeatState, DefeatStateConfiguration>(_stateConfig);
    }
}