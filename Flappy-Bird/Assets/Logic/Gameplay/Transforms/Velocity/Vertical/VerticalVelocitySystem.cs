using Entitas;
using System;

namespace FlappyBird.Gameplay.Transforms
{
    public class VerticalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly LevelContext _context;

        public VerticalVelocitySystem(LevelContext context)
        {
            _context = context;
            _movables = context.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.VerticalVelocity));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.y += Math.Clamp(
                    movable.verticalVelocity.Value,
                    movable.verticalVelocityClamp.MinValue,
                    movable.verticalVelocityClamp.MaxValue) * _context.time.DeltaTime;
            }
        }
    }
}