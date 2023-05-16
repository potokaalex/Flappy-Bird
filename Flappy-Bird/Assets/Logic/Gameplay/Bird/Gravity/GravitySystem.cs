using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class GravitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;
        private readonly DeltaTime _deltaTime;

        public GravitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _birdEntities = context.GetGroup(LevelMatcher.Bird);
            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                ApplyVelocity(entity);
        }

        private void ApplyVelocity(LevelEntity entity)
        {
            entity.verticalVelocity.Value +=
                entity.gravity.Acceleration * _deltaTime.Value;
        }
    }
}