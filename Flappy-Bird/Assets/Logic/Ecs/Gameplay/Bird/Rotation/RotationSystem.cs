using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly LevelContext _context;
        private readonly IGroup<LevelEntity> _birdEntities;

        public RotationSystem(LevelContext context)
        {
            _context = context;
            _birdEntities = context.GetGroup(LevelMatcher.Bird);
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                Rotate(entity);
        }

        private void Rotate(LevelEntity bird)
        {
            if (IsFly(bird))
                bird.rotationVelocity.Value = _context.birdData.ClockwiseAngularVelocity;
            else if (IsFall(bird))
                bird.rotationVelocity.Value = _context.birdData.CounterClockwiseAngularVelocity;
        }

        private bool IsFly(LevelEntity bird)
            => bird.verticalVelocity.Value > _context.birdData.VelocityToFlyRotation;

        private bool IsFall(LevelEntity bird)
            => bird.verticalVelocity.Value < _context.birdData.VelocityToFallRotation;
    }
}