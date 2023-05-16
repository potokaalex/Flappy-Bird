using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class InitializationSystem : IInitializeSystem
    {
        private readonly LevelContext _context;
        private readonly BirdConfiguration _config;

        public InitializationSystem(LevelContext context, BirdConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Initialize()
        {
            var bird = CreateBird();

            AddVelocityComponents(bird);
            AddRotationComponents(bird);
            AddOtherComponents(bird);
            EnableFlyUpAction(bird);
        }

        private LevelEntity CreateBird()
        {
            var entity = _context.CreateEntity();
            var gameObject = Object.Instantiate(_config.Prefab,
                _config.SpawnPoint, Quaternion.identity);

            gameObject.Link(entity);
            entity.AddLinkToGameObject(gameObject);
            entity.AddBirdData(
                _config.FlyUpAction,
                _config.FlyUpVelocity,
                _config.ClockwiseAngularVelocity,
                _config.CounterClockwiseAngularVelocity);

            entity.isBird = true;
            
            return entity;
        }

        private void AddVelocityComponents(LevelEntity bird)
        {
            bird.AddVerticalVelocity(0);
            bird.AddVerticalVelocityClamp(
                _config.MinVelocity, _config.MaxVelocity);
        }

        private void AddRotationComponents(LevelEntity bird)
        {
            bird.AddRotation(0);
            bird.AddRotationVelocity(0);
            bird.AddRotationClamp(_config.MinAngle, _config.MaxAngle);
        }

        private void AddOtherComponents(LevelEntity bird)
        {
            bird.AddGravity(_config.GravityAcceleration);
            bird.AddPosition(_config.SpawnPoint);
        }

        private void EnableFlyUpAction(LevelEntity entity)
            => entity.birdData.FlyUpAction.Enable();
    }
}