using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        private readonly Contexts _contexts;

        public BirdSystems(Contexts contexts, PlayerProgress progress, BirdConfiguration birdConfig)
        {
            _contexts = contexts;

            CreateEntities(contexts, progress, birdConfig);
            CreateSystems(contexts, progress);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
        }

        private void CreateEntities(Contexts contexts, PlayerProgress progress, BirdConfiguration birdConfig)
        {
            contexts.input.SetBirdData(
                progress.BirdFlyUpAction,
                birdConfig.FlyUpVelocity);
            
            new BirdFactory(contexts.level, contexts.input, progress,
                birdConfig).Create();

            contexts.input.birdData.FlyUpAction.Enable();
        }

        private void RemoveEntities()
        {
            _contexts.input.birdData.FlyUpAction.Disable();

            _contexts.input.RemoveBirdData();

            foreach (var bird in _contexts.level.GetEntities(LevelMatcher.Bird))
            {
                bird.linkToGameObject.GameObject.Unlink();
                bird.Destroy();
            }
        }

        private void CreateSystems(Contexts contexts, PlayerProgress progress)
        {
            //base.Add(new DeathSystem(contexts.input));
            base.Add(new InputSystem(contexts.level, contexts.input));
            base.Add(new FlyUpSystem(contexts.level, contexts.input));
            base.Add(new AnimationSystem(contexts.level));
            base.Add(new ScoreSystem(contexts.input, progress.Score));
        }
    }
}