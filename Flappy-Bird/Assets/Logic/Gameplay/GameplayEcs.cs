using FlappyBird.Gameplay.PreGameplay;
using FlappyBird.Gameplay.GameOver;
using System.Collections.Generic;
using FlappyBird.Gameplay.Basic;
using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;

namespace FlappyBird.Gameplay
{
    public class GameplayEcs
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;

        private List<GameplaySystems> _systems;
        private readonly IDataProvider _dataProvider;
        private Contexts _contexts;

        public GameplayEcs(IDataProvider dataProvider, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
            _dataProvider = dataProvider;
        }

        public Contexts Contexts
            => _contexts;

        public BasicSystems BasicSystems;
        public PreGameplaySystems PreGameplaySystems;
        public BirdSystems BirdSystems;
        public PipesSystems PipesSystems;
        public PreGameOverSystems PreGameOverSystems;

        public void Initialize()
        {
            _contexts = Contexts.sharedInstance = new();
            _systems = CreateSystems();

            foreach (var systems in _systems)
                systems.Initialize();
        }

        public void Dispose()
        {
            foreach (var systems in _systems)
            {
                systems.Stop();
                systems.Cleanup();
                systems.DeactivateReactiveSystems();
            }

            _contexts.Reset();
        }

        private List<GameplaySystems> CreateSystems()
        {
            BasicSystems = new(_contexts, _gameLoop);
            PreGameplaySystems = new(_contexts, _stateMachine, _gameLoop);
            BirdSystems = new(_contexts, _dataProvider.Get<PlayerProgress>(), _gameLoop);
            PipesSystems = new(_contexts, _dataProvider.Get<PlayerProgress>(), _gameLoop);
            PreGameOverSystems = new(_contexts, BirdSystems, PipesSystems, _stateMachine, _gameLoop);

            var systems = new List<GameplaySystems>();

            systems.Add(BasicSystems);
            systems.Add(PreGameplaySystems);
            systems.Add(BirdSystems);
            systems.Add(PipesSystems);
            systems.Add(PreGameOverSystems);

            return systems;
        }
    }
}