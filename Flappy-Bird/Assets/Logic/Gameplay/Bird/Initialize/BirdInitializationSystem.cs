using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdInitializationSystem : IInitializeSystem
    {
        private readonly LevelContext _context;
        private readonly BirdConfiguration _config;

        public BirdInitializationSystem(LevelContext context, BirdConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Initialize()
        {
            var bird = CreateBird();

            AddFlyComponents(bird);
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
            entity.isBird = true;

            return entity;
        }

        private void AddFlyComponents(LevelEntity bird)
        {
            bird.AddFlyUpData(_config.FlyUp.Action, _config.FlyUp.Velocity);
            bird.AddVerticalVelocity(0);
            bird.AddVerticalVelocityClamp(
                _config.FlyUp.MinVelocity, _config.FlyUp.MaxVelocity);
        }

        private void AddRotationComponents(LevelEntity bird)
        {
            bird.AddRotationData(_config.Rotation.CounterClockwiseVelocity,
                _config.Rotation.ClockwiseVelocity);
            
            bird.AddRotation(0);
            bird.AddRotationVelocity(0);
            bird.AddRotationClamp(_config.Rotation.MinAngle, _config.Rotation.MaxAngle);
        }

        private void AddOtherComponents(LevelEntity bird)
        {
            bird.AddGravity(_config.GravityAcceleration);
            bird.AddPosition(_config.SpawnPoint);
        }

        private void EnableFlyUpAction(LevelEntity entity)
            => entity.flyUpData.Action.Enable();
    }
}