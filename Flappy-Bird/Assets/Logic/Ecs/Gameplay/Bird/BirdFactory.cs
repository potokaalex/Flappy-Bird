using FlappyBird.Ecs.Basic.Collision;
using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly DataProvider _data;

        public BirdFactory(LevelContext levelContext, InputContext inputContext, DataProvider data)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _data = data;
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
            var gameObject = Object.Instantiate(_data.BirdConfig.Prefab,
                _data.PlayerProgress.BirdSpawnPoint, Quaternion.identity);

            gameObject.Link(entity);
            entity.AddLinkToGameObject(gameObject);
            entity.isBird = true;

            return (gameObject, entity);
        }

        private void AddComponents(LevelEntity bird)
        {
            bird.AddVerticalVelocity(0);
            bird.AddVerticalVelocityClamp(
                _data.BirdConfig.MinVelocity, _data.BirdConfig.MaxVelocity);

            bird.AddRotation(0);
            bird.AddRotationVelocity(0);
            bird.AddRotationClamp(_data.BirdConfig.MinAngle, _data.BirdConfig.MaxAngle);

            bird.AddGravity(_data.BirdConfig.GravityAcceleration);
            bird.AddPosition(_data.PlayerProgress.BirdSpawnPoint);
        }

        private void InitializeCollisionSender(GameObject bird)
        {
            if (bird.TryGetComponent<CollisionSender>(out var collisionSender))
                collisionSender.Initialize(_inputContext);
        }
    }
}