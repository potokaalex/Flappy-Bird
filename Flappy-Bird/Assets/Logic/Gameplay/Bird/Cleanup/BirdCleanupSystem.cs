using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdCleanupSystem : ICleanupSystem
    {
        private IGroup<LevelEntity> _birdEntities;
        private BirdConfiguration _config;

        public BirdCleanupSystem(LevelContext context, BirdConfiguration config)
        {
            _birdEntities = context.GetGroup(LevelMatcher.Bird);
            _config = config;
        }

        public void Cleanup()
        {
            foreach (var entity in _birdEntities.GetEntities())
                DestroyBird(entity);

            DisableFlyUpAction();
        }

        private void DestroyBird(LevelEntity entity)
        {
            var gameObject = entity.linkToGameObject.GameObject;
            
            gameObject.Unlink();
            Object.Destroy(gameObject);
            entity.Destroy();
        }

        private void DisableFlyUpAction()
            => _config.FlyUpAction.Disable();
    }
}
