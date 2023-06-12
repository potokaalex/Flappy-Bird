using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Bird;
using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    public class GameOverCheckSystem : ReactiveSystem<InputEntity>
    {
        private readonly IStateMachine _stateMachine;

        public GameOverCheckSystem(IStateMachine stateMachine, InputContext inputContext) : base(inputContext) 
            => _stateMachine = stateMachine;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision);

        protected override bool Filter(InputEntity entity)
            => IsSenderHasBird(entity) && (IsTriggerHasPipes(entity) || IsTriggerHasGrass(entity));

        protected override void Execute(List<InputEntity> entities) 
            => _stateMachine.SwitchTo<PreGameOverState>();

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<PipesCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);
    }
}