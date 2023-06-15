using FlappyBird.Gameplay.PreGameplay;
using System.Collections.Generic;
using FlappyBird.Gameplay.Core;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.PreGameOver;

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
            _contexts = Contexts.sharedInstance = new();
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
            _dataProvider = dataProvider;
        }

        public Contexts Contexts
            => _contexts;

        public PreGameplaySystems PreGameplaySystems;
        public CoreSystems CoreSystems;
        public PreGameOverSystems PreGameOverSystems;
        public GameOverSystems GameOverSystems;

        public void Initialize()
        {
            _systems = CreateSystems();

            //foreach (var systems in _systems)
            //    systems.Initialize();
        }

        public void Dispose()
        {
            foreach (var systems in _systems)
            {
                systems.Stop();
                systems.Cleanup();
            }

            _contexts.Reset();
        }

        private List<GameplaySystems> CreateSystems()
        {
            PreGameplaySystems = new(_contexts, _stateMachine, _gameLoop);
            CoreSystems = new(_contexts, _dataProvider.Get<PlayerProgress>(), _stateMachine, _gameLoop);
            PreGameOverSystems = new(_contexts, _stateMachine, _gameLoop);
            GameOverSystems = new(_contexts, _gameLoop);

            var systems = new List<GameplaySystems>();

            systems.Add(PreGameplaySystems);
            systems.Add(CoreSystems);
            systems.Add(PreGameOverSystems);
            systems.Add(GameOverSystems);

            return systems;
        }
    }
}