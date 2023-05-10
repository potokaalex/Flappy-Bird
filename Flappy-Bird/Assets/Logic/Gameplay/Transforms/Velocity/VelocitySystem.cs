using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class VelocitySystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _movables;
        private DeltaTime _deltaTime;

        public VelocitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _movables = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Position, LevelMatcher.Velocity));

            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var movable in _movables)
                movable.position.Value += movable.velocity.Value * _deltaTime.Value;
        }
    }
}
