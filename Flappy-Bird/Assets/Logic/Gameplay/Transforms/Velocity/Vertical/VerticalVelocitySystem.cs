using Entitas;
using System;

namespace FlappyBird.Gameplay.Transforms
{
    public class VerticalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly DeltaTime _deltaTime;

        public VerticalVelocitySystem(LevelContext context, DeltaTime deltaTime)
        {
            _movables = context.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.VerticalVelocity));

            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.y += Math.Clamp(
                    movable.verticalVelocity.Value,
                    movable.verticalVelocityClamp.MinValue,
                    movable.verticalVelocityClamp.MaxValue) * _deltaTime.Value;
            }
        }
    }
}