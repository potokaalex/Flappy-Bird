using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core.Grass
{
    public class GrassSystems : Feature
    {
        private readonly PlayerProgress _progress;
        private readonly Contexts _contexts;

        public GrassSystems(Contexts contexts, PlayerProgress progress)
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
            var material = new Material(_progress.GrassData.MeshRenderer.material);

            _progress.GrassData.MeshRenderer.material = material;

            _contexts.input.SetGrassData(material, _progress.GrassData.StaticData.ScrollVelocity);
        }

        private void RemoveEntities()
            => _contexts.input.RemoveGrassData();

        private Systems CreateSystems(Contexts contexts)
        {
            var systems = new Systems();

            base.Add(new AnimationSystem(contexts.input));

            return systems;
        }
    }
}