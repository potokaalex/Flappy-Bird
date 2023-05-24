using Entitas;

namespace FlappyBird.Ecs.Basic
{
    using Transforms;
    using GameOver;
    using Score;
    using Input;
    using Time;

    public class BasicSystems
    {
        private readonly IGameLoop _gameLoop;
        private readonly Systems _systems;

        public BasicSystems(Contexts contexts, DataProvider data,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _systems = CreateSystems(contexts, data, stateMachine);
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

        private Systems CreateSystems(Contexts contexts, DataProvider data, IStateMachine stateMachine)
        {
            return new Systems()
                //.Add(new TestSystem(contexts, data))
                .Add(new GameOverSystem(contexts.input, stateMachine))
                .Add(new ScoreSystem(contexts.input, data.PlayerProgress.Score))
                .Add(new TransformSystems(contexts))
                .Add(new InputCleanupSystem(contexts.input))
                .Add(new TimeSystems(contexts.input, _gameLoop.FixedDeltaTime));
        }
    }
}