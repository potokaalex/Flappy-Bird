using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Basic
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _entities;

        public RotationSystem(LevelContext context)
        {
            _entities = context.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.LinkToGameObject, LevelMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
                ApplyRotation(entity);
        }

        private void ApplyRotation(LevelEntity entity)
        {
            if (entity.hasRotationClamp)
                entity.rotation.Value = Math.Clamp(
                    entity.rotation.Value, entity.rotationClamp.MinValue, entity.rotationClamp.MaxValue);
            
            entity.linkToGameObject.GameObject.transform.rotation 
                = Quaternion.Euler(0, 0, entity.rotation.Value);
        }
    }
}