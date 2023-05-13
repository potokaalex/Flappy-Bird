using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Transforms
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _rotatable;

        public RotationSystem(LevelContext context)
        {
            _rotatable = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.LinkToGameObject, LevelMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
                Rotate(rotatable);
        }

        private void Rotate(LevelEntity entity)
        {
            if (entity.hasRotationClamp)
                entity.rotation.Value = Math.Clamp(
                    entity.rotation.Value, entity.rotationClamp.MinValue, entity.rotationClamp.MaxValue);

            entity.linkToGameObject.GameObject.transform.rotation
                = Quaternion.Euler(0, 0, entity.rotation.Value);
        }
    }
}