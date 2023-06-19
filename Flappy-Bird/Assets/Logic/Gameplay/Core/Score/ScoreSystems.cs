using Entitas;

namespace FlappyBird.Gameplay.Core.Score
{
    public class ScoreSystems : Feature
    {
        private readonly Contexts _contexts;

        public ScoreSystems(Contexts contexts, IPlayerProgress playerProgress)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, playerProgress));
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
            => _contexts.input.SetScoreData(0);

        private void RemoveEntities()
            => _contexts.input.RemoveScoreData();

        private Systems CreateSystems(Contexts contexts, IPlayerProgress playerProgress)
        {
            var systems = new Systems();

            base.Add(new ScoreCountSystem(contexts.input, playerProgress));

            return systems;
        }
    }
}