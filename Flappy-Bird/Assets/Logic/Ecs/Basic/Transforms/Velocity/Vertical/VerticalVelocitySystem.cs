using Entitas;
using System;

namespace FlappyBird.Ecs.Basic.Transforms
{
    public class VerticalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly InputContext _inputContext;

        public VerticalVelocitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _movables = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.VerticalVelocity));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.y += Math.Clamp(
                    movable.verticalVelocity.Value,
                    movable.verticalVelocityClamp.MinValue,
                    movable.verticalVelocityClamp.MaxValue) * _inputContext.time.DeltaTime;
            }
        }
    }
}