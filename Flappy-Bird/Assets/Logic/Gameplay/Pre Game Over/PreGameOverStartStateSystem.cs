using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Bird;
using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.PreGameOver
{
    public class PreGameOverStartStateSystem : ReactiveSystem<InputEntity>
    {
        private readonly IStateMachine _stateMachine;

        public PreGameOverStartStateSystem(IStateMachine stateMachine, InputContext inputContext) : base(inputContext)
            => _stateMachine = stateMachine;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision);

        protected override bool Filter(InputEntity entity)
            => IsSenderHasBird(entity) && (IsTriggerHasGrass(entity) || IsTriggerHasPipes(entity));

        protected override void Execute(List<InputEntity> entities)
            => _stateMachine.SwitchTo<PreGameOverState>();

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.OtherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.Collider.TryGetComponent<PipesCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.Collider.TryGetComponent<GrassCollider>(out _);
    }
}