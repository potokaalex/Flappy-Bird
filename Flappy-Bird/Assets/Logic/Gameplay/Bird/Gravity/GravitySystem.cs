using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class GravitySystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _birdEntities;
        private DeltaTime _deltaTime;

        public GravitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _birdEntities = context.GetGroup(LevelMatcher.Bird);
            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                ApplyGravity(entity);
        }

        private void ApplyGravity(LevelEntity entity)
        {
            var velocity = entity.velocity.Value.y - 
                entity.gravity.Acceleration * _deltaTime.Value;

            if (velocity < entity.gravity.MinVelocity)
                entity.velocity.Value.y = entity.gravity.MinVelocity;
            else
                entity.velocity.Value.y = velocity;
        }
    }
}
