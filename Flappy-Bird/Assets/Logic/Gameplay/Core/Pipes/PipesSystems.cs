using Entitas;
using Entitas.Unity;

namespace FlappyBird.Gameplay.Pipes
{
    public class PipesSystems : GameplaySystems
    {
        private readonly PlayerProgress _progress;
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;

        public PipesSystems(Contexts contexts, PlayerProgress progress, IGameLoop gameLoop)
        {
            _contexts = contexts;
            _gameLoop = gameLoop;
            _progress = progress;

            base.Add(CreateSystems(contexts));
            DeactivateReactiveSystems();
        }

        public override void Start()
        {
            ActivateReactiveSystems();
            _gameLoop.OnFixedUpdate += base.Execute;
        }

        public override void Stop()
        {
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

        private Systems CreateSystems(Contexts contexts)
        {
            var systems = new Systems();

            base.Add(new RemoveSystem(contexts.level, contexts.input));
            base.Add(new SpawnSystem(contexts.level, contexts.input));

            return systems;
        }

        private void CreateEntities()
        {
            var pipesFactory = new PipesFactory(_contexts.level, _progress);

            _contexts.input.SetPipesData(pipesFactory, _progress.PipesData.StaticData.SpawnDelay,
                _progress.PipesData.StaticData.SpawnRate, _progress.PipesData.StaticData.RemoveRate);
        }

        private void RemoveEntities()
        {
            _contexts.input.RemovePipesData();

            foreach (var pipes in _contexts.level.GetEntities(LevelMatcher.Pipes))
            {
                pipes.linkToGameObject.GameObject.Unlink();
                pipes.Destroy();
            }
        }
    }
}