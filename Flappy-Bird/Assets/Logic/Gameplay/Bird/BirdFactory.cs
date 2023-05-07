using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdFactory// ?
    {
        private BirdConfiguration _config;
        private LevelContext _context;

        public BirdFactory(LevelContext levelContext, BirdConfiguration config)
        {
            _context = levelContext;
            _config = config;
        }

        public void Create()
        {
            var gameObject = Object.Instantiate(_config.Prefab);
            var entity = _context.CreateEntity();

            gameObject.Link(entity);

            entity.AddLinkToGameObject(gameObject);
            entity.AddPosition(_config.SpawnPoint.position);
            entity.AddRotation(0);
            entity.AddVelocity(Vector2.zero);
            entity.AddGravity(_config.Acceleration, _config.MinVelocity);
            entity.isBird = true;
        }
    }
}
