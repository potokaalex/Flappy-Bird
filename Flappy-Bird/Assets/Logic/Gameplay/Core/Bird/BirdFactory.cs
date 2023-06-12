using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly PlayerProgress _progress;

        public BirdFactory(LevelContext levelContext, InputContext inputContext, PlayerProgress progress)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _progress = progress;
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
            var gameObject = Object.Instantiate(_progress.BirdData.BirdPrefab,
                _progress.BirdData.BirdSpawnPoint, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            entity.AddPositionClamp(
                new(float.MinValue, _progress.BirdData.StaticData.MinPositionY),
                new(float.MaxValue, _progress.BirdData.StaticData.MaxPositionY));

            entity.AddPosition(_progress.BirdData.BirdSpawnPoint);

            entity.AddVelocity(Vector2.zero);
            entity.AddVelocityClamp(
                new(float.MinValue, _progress.BirdData.StaticData.MinVelocity),
                new(float.MaxValue, _progress.BirdData.StaticData.MaxVelocity));

            entity.AddGravity(_progress.BirdData.StaticData.GravityAcceleration);
            entity.AddBirdAnimations(
                new(gameObject.GetComponent<Animator>()),
                _progress.BirdData.StaticData.VelocityToFallAnimation, false);

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