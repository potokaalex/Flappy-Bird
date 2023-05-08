using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdInitializationSystem : IInitializeSystem
    {
        private LevelEntity _birdEntity;
        private BirdConfiguration _config;

        public BirdInitializationSystem(LevelEntity birdEntity, BirdConfiguration config)
        {
            _birdEntity = birdEntity;
            _config = config;
        }

        public void Initialize()
        {
            var gameObject = Object.Instantiate(_config.Prefab, _config.SpawnPoint, Quaternion.identity);

            gameObject.Link(_birdEntity);

            _birdEntity.AddLinkToGameObject(gameObject);
            _birdEntity.AddPosition(_config.SpawnPoint);
            _birdEntity.AddRotation(0);
            _birdEntity.AddVelocity(Vector2.zero);
            _birdEntity.AddGravity(_config.Acceleration, _config.MinVelocity);
        }
    }
}
