using FlappyBird.Gameplay.Core.Bird;
using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Core.Score
{
    public class ScoreCountSystem : ReactiveSystem<InputEntity>
    {
        private readonly IPlayerProgress _playerProgress;
        private readonly InputContext _inputContext;

        public ScoreCountSystem(InputContext inputContext, IPlayerProgress playerProgress) : base(inputContext)
        {
            _playerProgress = playerProgress;
            _inputContext = inputContext;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity) && IsTriggerHasScore(inputEntity);

        protected override void Execute(List<InputEntity> entities)
        {
            _inputContext.scoreData.CurrentScore++;
            _playerProgress.SaveData();
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.OtherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasScore(InputEntity inputEntity)
            => inputEntity.collision.Info.Collider.TryGetComponent<ScoreCollider>(out _);
    }
}