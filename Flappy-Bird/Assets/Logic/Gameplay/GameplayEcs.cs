using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Gameplay.Basic;
using FlappyBird.Ecs.Defeat;
using Entitas.Unity;
using Entitas;

namespace FlappyBird
{
    public class GameplayEcs
    {
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;
        private readonly DataProvider _data;
        private readonly IStateMachine _stateMachine;
        private Systems _systems;

        public GameplayEcs(DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _contexts = Contexts.sharedInstance = new();
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
            _data = data;
        }

        public void Initialize(GameplayEcsConfiguration config)
        {
            _systems = CreateSystems(config);
            _systems.Initialize();
        }

        public void Dispose()
        {
            _systems.Cleanup();
            _contexts.Reset();
        }

        public void StartSystems()
            => _gameLoop.OnFixedUpdate += _systems.Execute;

        public void StopSystems()
            => _gameLoop.OnFixedUpdate -= _systems.Execute;

        private Systems CreateSystems(GameplayEcsConfiguration gameplayConfig)
        {
            var systems = new Systems();

            systems.Add(new BirdSystems(_contexts, _data, gameplayConfig.BirdConfiguration));
            systems.Add(new PipesSystems(_contexts, gameplayConfig.PipesConfiguration));
            systems.Add(new DevSystems(_contexts, _data, _stateMachine, _gameLoop));
            systems.Add(new GameOverSystems(_contexts, _stateMachine, _gameLoop));
            systems.Add(new BasicSystems(_contexts, _gameLoop));

            return systems;
        }
    }
}