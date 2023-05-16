using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class HorizontalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly LevelContext _context;

        public HorizontalVelocitySystem(LevelContext context)
        {
            _context = context;
            _movables = context.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.HorizontalVelocity));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.x +=
                    movable.horizontalVelocity.Value * _context.time.DeltaTime;
            }
        }
    }
}