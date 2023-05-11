using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdInitializationSystem : IInitializeSystem
    {
        private LevelContext _context;
        private BirdConfiguration _config;

        public BirdInitializationSystem(LevelContext context, BirdConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Initialize()
        {
            CreateBird();
            EnableFlyUpAction();
        }

        private void CreateBird()
        {
            var entity = _context.CreateEntity();
            var gameObject = Object.Instantiate(_config.Prefab,
                _config.SpawnPoint, Quaternion.identity);

            gameObject.Link(entity);

            entity.AddPosition(_config.SpawnPoint);
            entity.AddRotation(0);
            entity.AddVelocity(Vector2.zero);

            entity.AddLinkToGameObject(gameObject);
            entity.AddVerticalVelocityClamp(_config.MinVelocity, _config.MaxVelocity);
            entity.AddVerticalVelocity(0);
            entity.AddGravity(_config.GravityAcceleration);
            entity.isBird = true;
        }

        private void EnableFlyUpAction()
            => _config.FlyUpAction.Enable();
    }
}
