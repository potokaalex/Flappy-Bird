using FlappyBird.Ecs.Basic.Score;
using Entitas.Unity;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        private readonly Contexts _contexts;

        public BirdSystems(Contexts contexts, DataProvider data, BirdConfiguration birdConfig)
        {
            _contexts = contexts;

            CreateEntities(contexts, data, birdConfig);
            CreateSystems(contexts, data);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
        }

        private void CreateEntities(Contexts contexts, DataProvider data, BirdConfiguration birdConfig)
        {
            contexts.level.SetBirdData(
                birdConfig.FlyUpAction,
                birdConfig.FlyUpVelocity,
                birdConfig.ClockwiseAngularVelocity,
                birdConfig.CounterClockwiseAngularVelocity,
                birdConfig.VelocityToFlyRotation,
                birdConfig.VelocityToFallRotation);

            new BirdFactory(contexts.level, contexts.input, birdConfig,
                data.PlayerProgress.BirdSpawnPoint).Create();
        }

        private void RemoveEntities()
        {
            _contexts.level.RemoveBirdData();

            foreach (var bird in _contexts.level.GetEntities(LevelMatcher.Bird))
            {
                bird.linkToGameObject.GameObject.Unlink();
                bird.Destroy();
            }
        }

        private void CreateSystems(Contexts contexts, DataProvider data)
        {
            base.Add(new InitializationSystem(contexts.level));
            base.Add(new InputSystem(contexts.level, contexts.input));
            base.Add(new FlyUpSystem(contexts.level, contexts.input));
            base.Add(new RotationSystem(contexts.level));
            base.Add(new CollisionSystem(contexts.input));
            //base.Add(new GameOverSystem(contexts.level,contexts.input, this))
            base.Add(new ScoreSystem(contexts.input, data.PlayerProgress.Score));
            base.Add(new CleanupSystem(contexts.level));
        }
    }
}