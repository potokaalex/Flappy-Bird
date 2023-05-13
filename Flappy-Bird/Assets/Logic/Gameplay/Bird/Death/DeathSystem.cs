using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class DeathSystem : ReactiveSystem<LevelEntity>
    {
        private readonly InputContext _inputContext;

        public DeathSystem(InputContext inputContext, LevelContext levelContext) : base(levelContext)
            => _inputContext = inputContext;

        protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
            => context.CreateCollector(LevelMatcher.Collision.Added());

        protected override bool Filter(LevelEntity entity)
            => entity.isBird;

        protected override void Execute(List<LevelEntity> entities) 
            => _inputContext.isGameOver = true;
    }
}