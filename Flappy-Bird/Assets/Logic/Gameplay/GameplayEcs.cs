using FlappyBird.Gameplay.PreGameplay;
using FlappyBird.Gameplay.PreGameOver;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Core;

namespace FlappyBird.Gameplay
{
    public class GameplayEcs
    {
        private readonly IPlayerProgress _playerProgress;
        private readonly IDataProvider _dataProvider;
        private readonly IStateMachine _stateMachine;
        private readonly IGameLoop _gameLoop;
        private GameplaySystems _systems;

        public GameplayEcs(IPlayerProgress playerProgress, IDataProvider dataProvider,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _playerProgress = playerProgress;
            _dataProvider = dataProvider;
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;

            Contexts = Contexts.sharedInstance = new();
        }

        public Contexts Contexts { get; }

        public PreGameplaySystems PreGameplaySystems { get; private set; }

        public CoreSystems CoreSystems { get; private set; }

        public PreGameOverSystems PreGameOverSystems { get; private set; }

        public GameOverSystems GameOverSystems { get; private set; }
        
        public void Initialize()
        {
            CreateSystems();
            _systems.CreateEntities();
            _systems.Initialize();
            _systems.Stop(_gameLoop);
        }

        public void Dispose()
        {
            _systems.Stop(_gameLoop);
            _systems.Cleanup();
            _systems.RemoveEntities();
            Contexts.Reset();
        }
        
        private void CreateSystems()
        {
            _systems = new GameplaySystems();

            _systems.Add(PreGameplaySystems = new(Contexts, _stateMachine, _gameLoop));
            _systems.Add(CoreSystems = new(Contexts, _dataProvider, _stateMachine, _gameLoop, _playerProgress));
            _systems.Add(PreGameOverSystems = new(Contexts, _stateMachine, _gameLoop));
            _systems.Add(GameOverSystems = new(Contexts, _gameLoop));
        }
    }
}