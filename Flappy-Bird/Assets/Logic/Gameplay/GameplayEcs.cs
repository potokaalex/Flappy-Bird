using FlappyBird.Gameplay.PreGameplay;
using FlappyBird.Gameplay.PreGameOver;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Core;

namespace FlappyBird.Gameplay
{
    public class GameplayEcs
    {
        private readonly IDataProvider _dataProvider;
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerProgress _playerProgress;
        private readonly IGameLoop _gameLoop;

        private GameplaySystems[] _systems;

        public GameplayEcs(IDataProvider dataProvider, IStateMachine stateMachine,
            IPlayerProgress playerProgress, IGameLoop gameLoop)
        {
            _dataProvider = dataProvider;
            _stateMachine = stateMachine;
            _playerProgress = playerProgress;
            _gameLoop = gameLoop;
            
            Contexts = Contexts.sharedInstance = new();
        }

        public Contexts Contexts { get; }

        public PreGameplaySystems PreGameplaySystems { get; private set; }

        public CoreSystems CoreSystems { get; private set; }

        public PreGameOverSystems PreGameOverSystems { get; private set; }

        public GameOverSystems GameOverSystems { get; private set; }

        public void CreateSystems()
        {
            _systems = new GameplaySystems[4];

            _systems[0] = PreGameplaySystems = new(Contexts, _stateMachine, _gameLoop);
            _systems[1] = CoreSystems = new(Contexts, _dataProvider, _stateMachine, _gameLoop, _playerProgress);
            _systems[2] = PreGameOverSystems = new(Contexts, _stateMachine, _gameLoop);
            _systems[3] = GameOverSystems = new(Contexts, _gameLoop);
        }

        public void Dispose()
        {
            foreach (var systems in _systems)
            {
                systems.Stop();
                systems.Cleanup();
            }

            Contexts.Reset();
        }
    }
}