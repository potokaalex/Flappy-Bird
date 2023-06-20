using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Core.Pipes
{
    public class PipesSystems : Feature, IFactorySystem
    {
        private readonly IDataProvider _dataProvider;
        private readonly Contexts _contexts;

        public PipesSystems(Contexts contexts, IDataProvider dataProvider)
        {
            _contexts = contexts;
            _dataProvider = dataProvider;

            base.Add(CreateSystems(contexts));
        }

        public void CreateEntities()
        {
            var staticData = _dataProvider.Get<PipesStaticData>();
            var sceneData = _dataProvider.Get<PipesSceneData>();

            var pipesFactory = new PipesFactory(_contexts.level, staticData, sceneData);

            _contexts.input.SetPipesData(pipesFactory, staticData.SpawnDelay,
                staticData.SpawnRate, staticData.RemoveRate);
        }

        public void RemoveEntities()
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