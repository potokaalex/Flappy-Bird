using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class DeathSystem : ReactiveSystem<LevelEntity>
    {
        private LevelContext _context;

        public DeathSystem(LevelContext context) : base(context)
            => _context = context;

        protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
            => context.CreateCollector(LevelMatcher.Collision.Added());

        protected override bool Filter(LevelEntity entity)
            => entity.isBird;

        protected override void Execute(List<LevelEntity> entities)
            => _context.birdEntity.isGameOver = true;
    }
}
