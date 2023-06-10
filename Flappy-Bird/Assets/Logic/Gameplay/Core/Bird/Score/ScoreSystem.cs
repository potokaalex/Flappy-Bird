using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class ScoreSystem : ReactiveSystem<InputEntity>
    {
        private readonly Score _score;

        public ScoreSystem(InputContext context, Score score) : base(context)
            => _score = score;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity) && IsTriggerHasScore(inputEntity);

        protected override void Execute(List<InputEntity> entities) 
            => _score.IncreaseScore();

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasScore(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<ScoreCollider>(out _);
    }
}