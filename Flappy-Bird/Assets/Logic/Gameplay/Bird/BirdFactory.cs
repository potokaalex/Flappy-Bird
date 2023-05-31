using FlappyBird.Gameplay.Basic;
using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly BirdConfiguration _config;
        private readonly PlayerProgress _progress;

        public BirdFactory(LevelContext levelContext, InputContext inputContext,
            PlayerProgress progress, BirdConfiguration config)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _progress = progress;
            _config = config;
        }

        public void Create()
        {
            var entity = _levelContext.CreateEntity();
            var gameObject = CreateBirdGameObject(entity);

            AddComponents(entity, gameObject);
            InitializeCollisionSender(gameObject);
        }


        private GameObject CreateBirdGameObject(LevelEntity entity)
        {
            var gameObject = Object.Instantiate(_progress.BirdPrefab,
                _progress.BirdSpawnPoint, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            //
            entity.AddRotationVelocity(0);
            entity.AddRotationClamp(_config.MinAngle, _config.MaxAngle);
            //

            entity.AddRotation(0);
            entity.AddPositionClamp(
                new(float.MinValue, _config.MinPositionY),
                new(float.MaxValue, _config.MaxPositionY));

            entity.AddPosition(_progress.BirdSpawnPoint);

            entity.AddVelocity(Vector2.zero);
            entity.AddVelocityClamp(
                new(float.MinValue, _config.MinVelocity),
                new(float.MaxValue, _config.MaxVelocity));

            entity.AddGravity(_config.GravityAcceleration);

            entity.AddLinkToGameObject(gameObject);
            entity.isBird = true;
        }

        private void InitializeCollisionSender(GameObject bird)
        {
            if (bird.TryGetComponent<CollisionSender>(out var collisionSender))
                collisionSender.Initialize(_inputContext);
        }
    }
}