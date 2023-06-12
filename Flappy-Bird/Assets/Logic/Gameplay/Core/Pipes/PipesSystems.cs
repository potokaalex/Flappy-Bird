using Entitas;
using Entitas.Unity;

namespace FlappyBird.Gameplay.Core.Pipes
{
    public class PipesSystems : Feature
    {
        private readonly PlayerProgress _progress;
        private readonly Contexts _contexts;

        public PipesSystems(Contexts contexts, PlayerProgress progress)
        {
            _contexts = contexts;
            _progress = progress;

            base.Add(CreateSystems(contexts));
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

        private Systems CreateSystems(Contexts contexts)
        {
            var systems = new Systems();

            base.Add(new RemoveSystem(contexts.level, contexts.input));
            base.Add(new SpawnSystem(contexts.level, contexts.input));

            return systems;
        }
    }
}