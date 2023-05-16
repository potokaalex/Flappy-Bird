using FlappyBird.Gameplay.Transforms;
using FlappyBird.Gameplay.Collision;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Input;
using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
using FlappyBird.Gameplay.Time;
using FlappyBird.Extensions;

namespace FlappyBird.Infrastructure
{
    public class LevelEcs
    {
        private readonly BreakableSystems _systems;
        private readonly DataProvider _data;
        private readonly Contexts _contexts;
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;

        public LevelEcs(IStateMachine stateMachine, IGameLoop gameLoop, DataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
            _data = dataProvider;

            _contexts = new();
            _systems = new();

            FillSystems();
        }

        public void Initialize()
        {
            _systems.Initialize();

            _gameLoop.OnFixedUpdate += SystemsUpdate;
        }

        public void Cleanup()
        {
            _systems.Cleanup();

            _gameLoop.OnFixedUpdate -= SystemsUpdate;
        }

        private void FillSystems()
        {
            _systems
                .Add(new TimeSystems(_contexts.level, _gameLoop.FixedDeltaTime))
                .Add(new BirdSystems(_contexts, _data.BirdConfiguration))
                .Add(new GameOverSystem(_contexts.input, _systems,
                    _data.LevelLoadingConfiguration, _stateMachine))

                //.Add(new TestSystem(_contexts))
                .Add(new PipesSystems(_contexts.level, _data.PipesConfiguration))
                .Add(new TransformSystems(_contexts.level))
                .Add(new CollisionCleanupSystem(_contexts.level))
                .Add(new InputCleanupSystem(_contexts.input));
        }

        private void SystemsUpdate() 
            => _systems.Execute();
    }
}