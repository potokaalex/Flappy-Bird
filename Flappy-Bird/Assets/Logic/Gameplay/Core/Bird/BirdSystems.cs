using Entitas.Unity;
using Entitas;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class BirdSystems : Feature
    {
        private readonly Contexts _contexts;
        private readonly IDataProvider _dataProvider;

        public BirdSystems(Contexts contexts, IDataProvider dataProvider)
        {
            _contexts = contexts;
            _dataProvider = dataProvider;

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
            var staticData = _dataProvider.Get<BirdStaticData>();
            var sceneData = _dataProvider.Get<BirdSceneData>();
            var progress = _dataProvider.Get<ProgressData>();
            
            _contexts.input.SetBirdData(staticData.FlyUpAction, staticData.FlyUpVelocity);

            new BirdFactory(_contexts.level, _contexts.input, staticData, progress, sceneData).Create();

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

        private Systems CreateSystems(Contexts contexts)
        {
            var systems = new Systems();

            systems.Add(new InputSystem(contexts.input));
            systems.Add(new FlyUpSystem(contexts.level, contexts.input));
            systems.Add(new AnimationSystem(contexts.level, contexts.input));

            return systems;
        }
    }
}