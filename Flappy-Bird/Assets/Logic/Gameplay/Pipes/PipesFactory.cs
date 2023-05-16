using Unity.Mathematics;
using Entitas.Unity;
using UnityEngine;

using Random = Unity.Mathematics.Random;
using Object = UnityEngine.Object;

namespace FlappyBird.Gameplay.Pipes
{
    public class PipesFactory
    {
        private readonly LevelContext _context;
        private readonly PipesConfiguration _config;
        private Random _random;
        private float _lastPositionY;

        public PipesFactory(LevelContext context, PipesConfiguration config)
        {
            _context = context;
            _config = config;
            _random = new Random((uint) System.DateTime.Now.Ticks);
        }

        public void Create()
        {
            var entity = _context.CreateEntity();
            var gameObject = Object.Instantiate(_config.Prefab, Vector3.zero, Quaternion.identity);

            AddComponents(entity, gameObject);
            ResetPosition(entity);
        }

        public void ResetPosition(LevelEntity pipes)
        {
            var offsetY = _random.NextFloat(-_config.MaxOffsetY, _config.MaxOffsetY) / 2f;
            var positionY = math.clamp(_lastPositionY + offsetY,
                _config.MinPositionY, _config.MaxPositionY);

            if (positionY == _lastPositionY)
            {
                if (positionY <= _config.MinPositionY)
                    positionY -= offsetY;

                else if (positionY >= _config.MaxPositionY)
                    positionY -= offsetY;
            }

            pipes.position.Value = new(_config.SpawnPositionX, positionY);

            _lastPositionY = positionY;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            gameObject.Link(entity);
            entity.AddLinkToGameObject(gameObject);

            entity.AddPosition(gameObject.transform.position);
            entity.AddHorizontalVelocity(_config.Velocity);
            entity.AddLifetime(_config.RemoveRate);

            entity.isActive = true;
            entity.isPipes = true;
        }
    }
}