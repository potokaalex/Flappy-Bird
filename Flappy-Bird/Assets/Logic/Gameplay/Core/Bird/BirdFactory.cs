using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class BirdFactory
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly ProgressData _progressData;
        private readonly BirdStaticData _staticData;
        private readonly BirdSceneData _sceneData;

        public BirdFactory(LevelContext levelContext, InputContext inputContext, BirdStaticData staticData,
            ProgressData progressData, BirdSceneData sceneData)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _staticData = staticData;
            _progressData = progressData;
            _sceneData = sceneData;
        }

        public void Create()
        {
            var entity = _levelContext.CreateEntity();
            var gameObject = CreateBirdGameObject(entity);

            AddComponents(entity, gameObject);
            InitializeCollisionSender(gameObject);
            InitializeSkin(gameObject);
        }

        private GameObject CreateBirdGameObject(LevelEntity entity)
        {
            var gameObject = Object.Instantiate(_staticData.Appearance.Prefab,
                _sceneData.BirdSpawnPoint.position, Quaternion.identity);

            gameObject.Link(entity);

            return gameObject;
        }

        private void AddComponents(LevelEntity entity, GameObject gameObject)
        {
            entity.AddPositionClamp(
                new(float.MinValue, _staticData.MinPositionY),
                new(float.MaxValue, _staticData.MaxPositionY));

            entity.AddPosition(_sceneData.BirdSpawnPoint.position);

            entity.AddVelocity(Vector2.zero);
            entity.AddVelocityClamp(
                new(float.MinValue, _staticData.MinVelocityY),
                new(float.MaxValue, _staticData.MaxVelocityY));

            entity.AddGravity(_staticData.GravityAcceleration);
            entity.AddBirdAnimations(
                new(gameObject.GetComponent<Animator>()),
                _staticData.VelocityToFallAnimation, false);

            entity.AddLinkToGameObject(gameObject);
            entity.isBird = true;
        }

        private void InitializeCollisionSender(GameObject bird)
        {
            if (bird.TryGetComponent<CollisionSender>(out var collisionSender))
                collisionSender.Initialize(_inputContext);
        }

        private void InitializeSkin(GameObject bird)
        {
            if (bird.TryGetComponent<SpriteRenderer>(out var renderer))
                renderer.sprite = _staticData.Appearance.GetSkin(_progressData.BirdCurrentSkinIndex);
        }
    }
}