using Entitas;
using System;

namespace FlappyBird.Gameplay.Bird
{
    public class VerticalVelocitySystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _birdEntities;
        private DeltaTime _deltaTime;

        public VerticalVelocitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _birdEntities = context.GetGroup(LevelMatcher.Bird);
            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var bird in _birdEntities)
                ApplyVerticalVelocity(bird);
        }

        private void ApplyVerticalVelocity(LevelEntity entity)
        {
            entity.position.Value.y = Math.Clamp(
                entity.verticalVelocity.Value,
                entity.verticalVelocityClamp.MinValue,
                entity.verticalVelocityClamp.MaxValue) * _deltaTime.Value;
        }
    }
}
