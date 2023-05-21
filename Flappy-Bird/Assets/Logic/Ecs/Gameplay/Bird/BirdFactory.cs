using FlappyBird.Ecs.Basic.Collision;
using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly BirdConfiguration _config;

        public BirdFactory(LevelContext levelContext, InputContext inputContext, BirdConfiguration config)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _config = config;
        }

        public void Create()
        {
            var bird = CreateBird();

            AddComponents(bird.Item2);
            InitializeCollisionSender(bird.Item1);
        }

        private (GameObject, LevelEntity) CreateBird()
        {
            var entity = _levelContext.CreateEntity();
            var gameObject = Object.Instantiate(_config.Prefab,
                _config.SpawnPoint, Quaternion.identity);

            gameObject.Link(entity);
            entity.AddLinkToGameObject(gameObject);
            entity.isBird = true;

            return (gameObject, entity);
        }

        private void AddComponents(LevelEntity bird)
        {
            bird.AddVerticalVelocity(0);
            bird.AddVerticalVelocityClamp(
                _config.MinVelocity, _config.MaxVelocity);

            bird.AddRotation(0);
            bird.AddRotationVelocity(0);
            bird.AddRotationClamp(_config.MinAngle, _config.MaxAngle);

            bird.AddGravity(_config.GravityAcceleration);
            bird.AddPosition(_config.SpawnPoint);
        }

        private void InitializeCollisionSender(GameObject bird)
        {
            if (bird.TryGetComponent<CollisionSender>(out var collisionSender))
                collisionSender.Initialize(_inputContext);
        }
    }
}