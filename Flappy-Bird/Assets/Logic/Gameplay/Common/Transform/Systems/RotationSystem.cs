using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Common.Transforms
{
    public class RotationSystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _rotatable;

        public RotationSystem(LevelContext context)
        {
            _rotatable = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.LinkToGameObject, LevelMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
            {
                rotatable.linkToGameObject.GameObject.transform.rotation 
                    = Quaternion.Euler(0, 0, rotatable.rotation.Value);
            }
        }
    }
}
