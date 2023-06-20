using Entitas;

namespace FlappyBird.Gameplay.Core
{
    public class CommonSystems : Feature, IFactorySystem
    {
        private readonly IGameLoop _gameLoop;
        private readonly Contexts _contexts;

        public CommonSystems(Contexts contexts, IGameLoop gameLoop)
        {
            _contexts = contexts;
            _gameLoop = gameLoop;

            base.Add(CreateSystems(contexts, gameLoop));
        }

        public void CreateEntities()
            => _contexts.input.SetTime(_gameLoop.FixedDeltaTime.Value);

        public void RemoveEntities()
            => _contexts.input.RemoveTime();

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop)
        {
            var systems = new Systems();

            systems.Add(new GravitySystem(contexts.level, contexts.input));
            systems.Add(new TransformSystems(contexts));
            systems.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));
            systems.Add(new EventCleanupSystem(contexts.input));

            return systems;
        }
    }
}