using System.Collections.Generic;
using FlappyBird.Infrastructure;
using FlappyBird.Gameplay.Bird;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverStartStateSystem : ReactiveSystem<InputEntity>
    {
        private readonly IStateMachine _stateMachine;

        public GameOverStartStateSystem(IStateMachine stateMachine, InputContext inputContext) : base(inputContext)
            => _stateMachine = stateMachine;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision);

        protected override bool Filter(InputEntity entity)
            => IsSenderHasBird(entity) && IsTriggerHasGrass(entity);

        protected override void Execute(List<InputEntity> entities)
            => _stateMachine.SwitchTo<GameOverState>();

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);
    }
}