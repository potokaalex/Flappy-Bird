using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core.Grass
{
    public class GrassSystems : Feature
    {
        private readonly IDataProvider _dataProvider;
        private readonly Contexts _contexts;

        public GrassSystems(Contexts contexts, IDataProvider dataProvider)
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
            var staticData = _dataProvider.Get<GrassStaticData>();
            var sceneData = _dataProvider.Get<GrassSceneData>();
            var material = new Material(sceneData.MeshRenderer.material);

            sceneData.MeshRenderer.material = material;
            _contexts.input.SetGrassData(material, staticData.ScrollVelocity);
        }

        private void RemoveEntities()
            => _contexts.input.RemoveGrassData();

        private Systems CreateSystems(Contexts contexts)
        {
            var systems = new Systems();

            base.Add(new GrassAnimationSystem(contexts.input));

            return systems;
        }
    }
}