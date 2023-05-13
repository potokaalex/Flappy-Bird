using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class RotationVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _rotatable;
        private readonly DeltaTime _deltaTime;

        public RotationVelocitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _rotatable = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.RotationVelocity, LevelMatcher.Rotation));

            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
                rotatable.rotation.Value += rotatable.rotationVelocity.Value * _deltaTime.Value;
        }
    }
}