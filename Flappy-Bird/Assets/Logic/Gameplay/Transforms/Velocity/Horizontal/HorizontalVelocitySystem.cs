using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class HorizontalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly DeltaTime _deltaTime;

        public HorizontalVelocitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _movables = context.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.HorizontalVelocity));

            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.x +=
                    movable.horizontalVelocity.Value * _deltaTime.Value;
            }
        }
    }
}