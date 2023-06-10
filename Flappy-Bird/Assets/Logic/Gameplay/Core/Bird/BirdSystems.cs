using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : GameplaySystems
    {
        private readonly PlayerProgress _progress;
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;

        public BirdSystems(Contexts contexts, PlayerProgress progress, IGameLoop gameLoop)
        {
            _contexts = contexts;
            _gameLoop = gameLoop;
            _progress = progress;

            base.Add(CreateSystems(contexts, progress));
            DeactivateReactiveSystems();
        }

        public override void Start()
        {
            _contexts.input.birdData.FlyUpAction.Enable();

            ActivateReactiveSystems();
            _gameLoop.OnFixedUpdate += base.Execute;
        }

        public override void Stop()
        {
            _contexts.input.birdData.FlyUpAction.Disable();

            DeactivateReactiveSystems();
            _gameLoop.OnFixedUpdate -= base.Execute;
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

        private Systems CreateSystems(Contexts contexts, PlayerProgress progress)
        {
            var systems = new Systems();

            systems.Add(new InputSystem(contexts.input));
            systems.Add(new FlyUpSystem(contexts.level, contexts.input));
            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new ScoreSystem(contexts.input, progress.Score));

            return systems;
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
    }
}