using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Ecs.Basic.Score
{
    public class ScoreSystem : ReactiveSystem<InputEntity>
    {
        private readonly FlappyBird.Score _score;

        public ScoreSystem(InputContext context, FlappyBird.Score score) : base(context)
            => _score = score;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.ScoreAdd.Added());

        protected override bool Filter(InputEntity entity)
            => true;

        protected override void Execute(List<InputEntity> entities)
            => _score.IncreaseScore();
    }
}