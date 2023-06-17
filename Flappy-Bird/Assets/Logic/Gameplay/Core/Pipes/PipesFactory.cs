using Unity.Mathematics;
using Entitas.Unity;
using UnityEngine;

using Random = Unity.Mathematics.Random;
using Object = UnityEngine.Object;

namespace FlappyBird.Gameplay.Core.Pipes
{
    public class PipesFactory
    {
        private readonly PipesStaticData _staticData;
        private readonly PipesSceneData _sceneData;
        private readonly LevelContext _context;
        private Random _random;
        private float _lastPositionY;

        public PipesFactory(LevelContext context, PipesStaticData staticData, PipesSceneData sceneData)
        {
            _random = new Random((uint)System.DateTime.Now.Ticks);

            _context = context;
            _staticData = staticData;
            _sceneData = sceneData;
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
                -_staticData.MaxOffsetY, _staticData.MaxOffsetY) / 2f;
            var positionY = math.clamp(_lastPositionY + offsetY,
                _staticData.MinPositionY, _staticData.MaxPositionY);

            if (positionY == _lastPositionY)
            {
                if (positionY <= _staticData.MinPositionY)
                    positionY -= offsetY;

                else if (positionY >= _staticData.MaxPositionY)
                    positionY -= offsetY;
            }

            pipes.position.Value = new(_sceneData.PipesSpawnPoint.position.x, positionY);

            _lastPositionY = positionY;
        }

        private GameObject CreateGameObject(LevelEntity entity)
        {
            var gameObject = Object.Instantiate(_staticData.Prefab, Vector3.zero, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            entity.AddPosition(gameObject.transform.position);
            entity.AddVelocity(new(_staticData.VelocityY, 0));
            entity.AddLifetime(_staticData.RemoveRate);

            entity.AddLinkToGameObject(gameObject);
            entity.isActive = true;
            entity.isPipes = true;
        }
    }
}