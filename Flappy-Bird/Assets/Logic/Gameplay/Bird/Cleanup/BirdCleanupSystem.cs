using FlappyBird.Extensions;
using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdCleanupSystem : ICleanupSystem
    {
        private LevelEntity _birdEntity;

        public BirdCleanupSystem(LevelEntity birdEntity)
            => _birdEntity = birdEntity;

        public void Cleanup()
        {
            _birdEntity.linkToGameObject.GameObject.Unlink();
            _birdEntity.RemoveAllComponentsExcept(LevelComponentsLookup.Bird);
        }
    }
}
