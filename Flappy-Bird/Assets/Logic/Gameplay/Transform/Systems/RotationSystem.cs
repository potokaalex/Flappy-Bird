using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class RotationSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _rotatable;

        public RotationSystem(Contexts contexts)
        {
            _rotatable = contexts.game.GetGroup(
                GameMatcher.AllOf(GameMatcher.LinkToGameObject, GameMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
            {
                rotatable.linkToGameObject.GameObject.transform.rotation = new Quaternion()
                {
                    eulerAngles = Vector3.forward * rotatable.rotation.Value
                };
            }
        }
    }
}
