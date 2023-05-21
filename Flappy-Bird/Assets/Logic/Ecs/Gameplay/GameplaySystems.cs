using Entitas;

namespace FlappyBird.Ecs.Gameplay
{
    using Bird;
    using Pipes;

    public class GameplaySystems
    {
        private readonly IGameLoop _gameLoop;
        private readonly Systems _systems;

        public GameplaySystems(Contexts contexts, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _systems = CreateSystems(contexts);
        }

        public void Initialize()
        {
            _systems.Initialize();
            _gameLoop.OnFixedUpdate += _systems.Execute;
        }

        public void Dispose()
        {
            _systems.Cleanup();
            _gameLoop.OnFixedUpdate -= _systems.Execute;
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Systems()
                //.Add(new TestSystem(contexts))
                .Add(new BirdSystems(contexts))
                .Add(new PipesSystems(contexts));
        }
    }
}