using Unity.Mathematics;
using Entitas.Unity;
using UnityEngine;

using Random = Unity.Mathematics.Random;
using Object = UnityEngine.Object;

namespace FlappyBird.Gameplay.Pipes
{
    public class PipesFactory
    {
        private readonly PlayerProgress _progress;
        private readonly LevelContext _context;
        private Random _random;
        private float _lastPositionY;

        public PipesFactory(LevelContext context, PlayerProgress progress)
        {
            _random = new Random((uint)System.DateTime.Now.Ticks);

            _progress = progress;
            _context = context;
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
            var offsetY = _random.NextFloat(
                -_progress.PipesData.StaticData.MaxOffsetY, _progress.PipesData.StaticData.MaxOffsetY) / 2f;
            var positionY = math.clamp(_lastPositionY + offsetY,
                _progress.PipesData.StaticData.MinPositionY, _progress.PipesData.StaticData.MaxPositionY);

            if (positionY == _lastPositionY)
            {
                if (positionY <= _progress.PipesData.StaticData.MinPositionY)
                    positionY -= offsetY;

                else if (positionY >= _progress.PipesData.StaticData.MaxPositionY)
                    positionY -= offsetY;
            }

            pipes.position.Value = new(_progress.PipesData.PipesSpawnPointX, positionY);

            _lastPositionY = positionY;
        }

        private GameObject CreateGameObject(LevelEntity entity)
        {
            var gameObject = Object.Instantiate(_progress.PipesData.PipesPrefab, Vector3.zero, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            entity.AddPosition(gameObject.transform.position);
            entity.AddVelocity(new(_progress.PipesData.StaticData.Velocity, 0));
            entity.AddLifetime(_progress.PipesData.StaticData.RemoveRate);

            entity.AddLinkToGameObject(gameObject);
            entity.isActive = true;
            entity.isPipes = true;
        }
    }
}