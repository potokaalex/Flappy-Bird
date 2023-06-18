using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        public BirdStaticData BirdStaticData;
        public PipesStaticData PipesStaticData;
        public GrassStaticData GrassStaticData;
        public ProgressData DefaultProgressData;

        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IGameLoop _gameLoop;
        private IDataProvider _dataProvider;
        private IPlayerProgress _playerProgress;

        [Inject]
        public void Constructor(IDataProvider dataProvider,IPlayerProgress playerProgress, IStateMachine stateMachine,
            IStateFactory stateFactory, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _gameLoop = gameLoop;
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;
            
            Initialize(); //move to start in bootstrap scene.
        }

        private void Initialize()
        {
            InitializeStateMachine();
            InitializeDataProvider();
            InitializePlayerProgress();
        }

        private void InitializePlayerProgress() 
            => _playerProgress.Initialize(DefaultProgressData);

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<SceneLoadingState>(),
                _stateFactory.Create<PreGameplayState>(),
                _stateFactory.Create<GameplayState>(),
                _stateFactory.Create<PauseState>(),
                _stateFactory.Create<PreGameOverState>(),
                _stateFactory.Create<GameOverState>());
        }
        
        private void InitializeDataProvider()
        {
            _dataProvider.Set(
                BirdStaticData,
                PipesStaticData,
                GrassStaticData,
                new GameOverStateConfiguration());
        }
    }
}