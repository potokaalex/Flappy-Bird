using Entitas;

namespace FlappyBird.Ecs.Basic
{
    using Transforms;
    using GameOver;
    using Input;
    using Time;

    public class BasicSystems
    {
        private readonly IGameLoop _gameLoop;
        private readonly Systems _systems;

        public BasicSystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _systems = CreateSystems(contexts, stateMachine);
        }

        public void Initialize()
        {
            _systems.Initialize();
            _gameLoop.OnLateFixedUpdate += _systems.Execute;
        }

        public void Dispose()
        {
            _systems.Cleanup();
            _gameLoop.OnLateFixedUpdate -= _systems.Execute;
        }

        private Systems CreateSystems(Contexts contexts, IStateMachine stateMachine)
        {
            return new Systems()
                .Add(new GameOverSystem(contexts.input, default, stateMachine)) // !
                .Add(new TransformSystems(contexts))
                .Add(new InputCleanupSystem(contexts.input))
                .Add(new TimeSystems(contexts.input, _gameLoop.FixedDeltaTime));
        }
    }
}