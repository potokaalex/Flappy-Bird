using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class BirdSystems : Feature
    {
        private readonly PlayerProgress _progress;
        private readonly Contexts _contexts;

        public BirdSystems(Contexts contexts, PlayerProgress progress)
        {
            _contexts = contexts;
            _progress = progress;

            base.Add(CreateSystems(contexts, progress));
        }

        public override void Initialize()
        {
            CreateEntities();
            base.Initialize();
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
        }

        private void CreateEntities()
        {
            _contexts.input.SetBirdData(
                _progress.BirdData.BirdFlyUpAction,
                _progress.BirdData.StaticData.FlyUpVelocity);

            new BirdFactory(_contexts.level, _contexts.input, _progress).Create();

            _contexts.input.birdData.FlyUpAction.Enable();
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
        
        private Systems CreateSystems(Contexts contexts, PlayerProgress progress)
        {
            var systems = new Systems();

            systems.Add(new InputSystem(contexts.input));
            systems.Add(new FlyUpSystem(contexts.level, contexts.input));
            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new ScoreSystem(contexts.input, progress.Score));

            return systems;
        }
    }
}