using Entitas.Unity;
using FlappyBird.Gameplay.Basic;
using UnityEngine;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly BirdConfiguration _config;
        private readonly Vector2 _spawnPoint;

        public BirdFactory(LevelContext levelContext, InputContext inputContext,
            BirdConfiguration config, Vector2 spawnPoint)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _config = config;
            _spawnPoint = spawnPoint;
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
                _spawnPoint, Quaternion.identity);

            gameObject.Link(entity);
            entity.AddLinkToGameObject(gameObject);
            entity.isBird = true;

            return (gameObject, entity);
        }

        private void AddComponents(LevelEntity bird)
        {
            bird.AddVelocity(Vector2.zero);
            bird.AddVelocityClamp(
                new(float.MinValue, _config.MinVelocity),
                new(float.MaxValue, _config.MaxVelocity));

            //bird.AddVerticalVelocity(0);
            //bird.AddVerticalVelocityClamp(
            //    _config.MinVelocity, _config.MaxVelocity);

            bird.AddRotation(0);
            bird.AddRotationVelocity(0);
            bird.AddRotationClamp(_config.MinAngle, _config.MaxAngle);

            bird.AddGravity(_config.GravityAcceleration);
            bird.AddPosition(_spawnPoint);
        }

        private void InitializeCollisionSender(GameObject bird)
        {
            if (bird.TryGetComponent<CollisionSender>(out var collisionSender))
                collisionSender.Initialize(_inputContext);
        }
    }
}