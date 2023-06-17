using FlappyBird.Gameplay.Core.Bird;
using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Core.Score
{
    public class ScoreSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;

        public ScoreSystem(InputContext inputContext) : base(inputContext)
            => _inputContext = inputContext;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity) && IsTriggerHasScore(inputEntity);

        protected override void Execute(List<InputEntity> entities)
            => _inputContext.scoreData.CurrentScore++;

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.OtherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasScore(InputEntity inputEntity)
            => inputEntity.collision.Info.Collider.TryGetComponent<ScoreCollider>(out _);
    }
}