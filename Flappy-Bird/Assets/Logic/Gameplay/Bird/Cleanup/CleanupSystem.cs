using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class CleanupSystem : ICleanupSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;

        public CleanupSystem(LevelContext context)
            => _birdEntities = context.GetGroup(LevelMatcher.Bird);

        public void Cleanup()
        {
            foreach (var entity in _birdEntities.GetEntities())
            {
                DisableFlyUpAction(entity);
                CleanupBird(entity);
            }
        }

        private void CleanupBird(LevelEntity entity)
        {
            var gameObject = entity.linkToGameObject.GameObject;

            gameObject.Unlink();
            Object.Destroy(gameObject);
            entity.Destroy();
        }

        private void DisableFlyUpAction(LevelEntity entity)
            => entity.birdData.FlyUpAction.Disable();
    }
}