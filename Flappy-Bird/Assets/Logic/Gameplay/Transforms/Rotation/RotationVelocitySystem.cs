using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class RotationVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _rotatable;
        private readonly LevelContext _context;

        public RotationVelocitySystem(LevelContext context)
        {
            _context = context;
            _rotatable = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.RotationVelocity, LevelMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
                rotatable.rotation.Value += rotatable.rotationVelocity.Value * _context.time.DeltaTime;
        }
    }
}