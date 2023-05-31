using FlappyBird.Gameplay.Basic;
using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
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
            StopSystems();
            
            _systems.Cleanup();
            _systems.DeactivateReactiveSystems();
            _contexts.Reset();
        }

        public void StartSystems()
            => _gameLoop.OnFixedUpdate += _systems.Execute;

        public void StopSystems()
            => _gameLoop.OnFixedUpdate -= _systems.Execute;

        private Systems CreateSystems(GameplayEcsConfiguration gameplayConfig)
        {
            var systems = new Systems();

            systems.Add(new BirdSystems(_contexts, _data.PlayerProgress, gameplayConfig.BirdConfiguration));
            systems.Add(new PipesSystems(_contexts, _data.PlayerProgress, gameplayConfig.PipesConfiguration));
            systems.Add(new DevSystems(_contexts, _data, _stateMachine, _gameLoop));
            systems.Add(new BasicSystems(_contexts, _stateMachine, _gameLoop));

            return systems;
        }
    }
}