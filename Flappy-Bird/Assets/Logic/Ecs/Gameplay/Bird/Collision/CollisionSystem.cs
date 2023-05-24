using FlappyBird.Ecs.Gameplay.Pipes;
using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class CollisionSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;

        public CollisionSystem(InputContext inputContext) : base(inputContext)
            => _inputContext = inputContext;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity);

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
                Handle(inputEntity);
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<PipesCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private bool IsTriggerHasScore(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<ScoreCollider>(out _);

        private void Handle(InputEntity inputEntity)
        {
            if (IsTriggerHasScore(inputEntity))
                _inputContext.isScoreAdd = true;

            else if (IsTriggerHasPipes(inputEntity) || IsTriggerHasGrass(inputEntity))
                _inputContext.isGameOver = true;
        }
    }
}