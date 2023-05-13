using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdCleanupSystem : ICleanupSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;

        public BirdCleanupSystem(LevelContext context)
            => _birdEntities = context.GetGroup(LevelMatcher.Bird);

        public void Cleanup()
        {
            foreach (var entity in _birdEntities.GetEntities())
                CleanupBird(entity);
        }

        private void CleanupBird(LevelEntity entity)
        {
            var gameObject = entity.linkToGameObject.GameObject;

            entity.flyUpData.Action.Disable();
            gameObject.Unlink();
            Object.Destroy(gameObject);
            entity.Destroy();
        }
    }
}