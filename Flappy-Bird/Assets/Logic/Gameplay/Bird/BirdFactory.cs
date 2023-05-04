using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdFactory
    {
        private BirdConfiguration _config;
        private Contexts _contexts;

        public BirdFactory(Contexts contexts)
        {
            _config = contexts.config.birdConfiguration;
            _contexts = contexts;
        }

        public void Create()
        {
            var gameObject = Object.Instantiate(_config.Prefab);
            var entity = _contexts.game.CreateEntity();

            entity.AddLinkToGameObject(gameObject);
            entity.AddPosition(_config.SpawnPoint.position);
            entity.AddRotation(0);
            entity.AddVelocity(Vector2.zero);
            entity.isBird = true;
        }
    }
}
