using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class PipesSystems : Feature
    {
        private readonly Contexts _contexts;

        public PipesSystems(Contexts contexts, PlayerProgress progress, PipesConfiguration pipesConfig)
        {
            _contexts = contexts;

            CreateEntities(contexts, progress, pipesConfig);
            CreateSystems(contexts);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
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

        private void CreateEntities(Contexts contexts, PlayerProgress progress, PipesConfiguration pipesConfig)
        {
            var pipesFactory = new PipesFactory(contexts.level, progress, pipesConfig);

            contexts.input.SetPipesData(pipesFactory, pipesConfig.SpawnDelay,
                pipesConfig.SpawnRate, pipesConfig.RemoveRate);
        }

        private void CreateSystems(Contexts contexts)
        {
            base.Add(new GameOverSystem(contexts.level, contexts.input));
            base.Add(new RemoveSystem(contexts.level, contexts.input));
            base.Add(new SpawnSystem(contexts.level, contexts.input));
        }
    }
}