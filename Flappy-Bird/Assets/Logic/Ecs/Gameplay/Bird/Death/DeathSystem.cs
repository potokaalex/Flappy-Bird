using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class DeathSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;

        public DeathSystem(LevelContext levelContext, InputContext inputContext) : base(inputContext)
            => _inputContext = inputContext;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity);

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
                Death(inputEntity);
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<Bird>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<Pipes.Pipes>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<Grass>(out _);

        private void Death(InputEntity inputEntity)
        {
            if (IsTriggerHasPipes(inputEntity) || IsTriggerHasGrass(inputEntity))
                _inputContext.isGameOver = true;
        }
    }
}