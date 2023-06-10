using System.Collections.Generic;
using FlappyBird.Infrastructure;
using Entitas;

namespace FlappyBird.Gameplay.PreGameplay
{
    public class GameplayStartStateSystem : ReactiveSystem<InputEntity>
    {
        private readonly IStateMachine _stateMachine;

        public GameplayStartStateSystem(IStateMachine stateMachine, InputContext inputContext) : base(inputContext)
            => _stateMachine = stateMachine;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.FlyUp.Added());

        protected override bool Filter(InputEntity entity)
            => true;

        protected override void Execute(List<InputEntity> entities)
            => _stateMachine.SwitchTo<GameplayState>();
    }
}