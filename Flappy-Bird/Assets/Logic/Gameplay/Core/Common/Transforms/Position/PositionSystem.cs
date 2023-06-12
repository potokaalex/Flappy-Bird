using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Core
{
    public class PositionSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _entities;

        public PositionSystem(LevelContext levelContext)
        {
            _entities = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.LinkToGameObject, LevelMatcher.Position));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
                ApplyPosition(entity);
        }

        private void ApplyPosition(LevelEntity entity)
        {
            if (entity.hasPositionClamp)
                entity.position.Value = Clamp(
                    entity.position.Value, entity.positionClamp.MinValue, entity.positionClamp.MaxValue);

            entity.linkToGameObject.GameObject.transform.position = entity.position.Value;
        }

        private Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            return new(
                Math.Clamp(value.x, min.x, max.x),
                Math.Clamp(value.y, min.y, max.y));
        }
    }
}