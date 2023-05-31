using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;
        private readonly InputContext _inputContext;

        public RotationSystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;

            _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                Rotate(entity);
        }

        private void Rotate(LevelEntity bird)
        {
            if (IsFly(bird))
                bird.rotationVelocity.Value = _inputContext.birdData.ClockwiseAngularVelocity;
            else if (IsFall(bird))
                bird.rotationVelocity.Value = _inputContext.birdData.CounterClockwiseAngularVelocity;
        }

        private bool IsFly(LevelEntity bird)
            => bird.velocity.Value.y > _inputContext.birdData.VelocityToFlyRotation;

        private bool IsFall(LevelEntity bird)
            => bird.velocity.Value.y < _inputContext.birdData.VelocityToFallRotation;
    }
}