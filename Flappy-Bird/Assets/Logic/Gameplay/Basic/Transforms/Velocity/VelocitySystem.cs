using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Basic
{
    public class VelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _entities;
        private readonly InputContext _inputContext;

        public VelocitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _entities = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
                ApplyVelocity(entity);
        }

        private void ApplyVelocity(LevelEntity entity)
        {
            var velocity = entity.hasVelocityClamp
                ? Clamp(entity.velocity.Value, entity.velocityClamp.MinValue, entity.velocityClamp.MaxValue)
                : entity.velocity.Value;

            entity.position.Value += velocity * _inputContext.time.DeltaTime;
        }

        private Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            return new(
                Math.Clamp(value.x, min.x, max.x),
                Math.Clamp(value.y, min.y, max.y));
        }
    }
}