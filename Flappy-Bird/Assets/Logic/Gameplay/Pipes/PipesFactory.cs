using Unity.Mathematics;
using Entitas.Unity;
using UnityEngine;

using Random = Unity.Mathematics.Random;
using Object = UnityEngine.Object;

namespace FlappyBird.Gameplay.Pipes
{
    public class PipesFactory
    {
        private readonly PipesConfiguration _config;
        private readonly PlayerProgress _progress;
        private readonly LevelContext _context;
        private Random _random;
        private float _lastPositionY;

        public PipesFactory(LevelContext context, PlayerProgress progress, PipesConfiguration config)
        {
            _random = new Random((uint) System.DateTime.Now.Ticks);

            _progress = progress;
            _context = context;
            _config = config;
        }

        public void Create()
        {
            var entity = _context.CreateEntity();
            var gameObject = CreateGameObject(entity);

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

            pipes.position.Value = new(_progress.PipesSpawnPointX, positionY);

            _lastPositionY = positionY;
        }

        private GameObject CreateGameObject(LevelEntity entity)
        {
            var gameObject = Object.Instantiate(_progress.PipesPrefab, Vector3.zero, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            entity.AddPosition(gameObject.transform.position);
            entity.AddVelocity(new(_config.Velocity, 0));
            entity.AddLifetime(_config.RemoveRate);

            entity.AddLinkToGameObject(gameObject);
            entity.isActive = true;
            entity.isPipes = true;
        }
    }
}