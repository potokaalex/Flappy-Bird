using Entitas;

namespace FlappyBird.Gameplay.Core.Score
{
    public class ScoreSystems : Feature, IFactorySystem
    {
        private readonly Contexts _contexts;

        public ScoreSystems(Contexts contexts, IPlayerProgress playerProgress)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, playerProgress));
        }

        public void CreateEntities()
            => _contexts.input.SetScoreData(0);

        public void RemoveEntities()
            => _contexts.input.RemoveScoreData();

        private Systems CreateSystems(Contexts contexts, IPlayerProgress playerProgress)
        {
            var systems = new Systems();

            base.Add(new ScoreCountSystem(contexts.input, playerProgress));

            return systems;
        }
    }
}