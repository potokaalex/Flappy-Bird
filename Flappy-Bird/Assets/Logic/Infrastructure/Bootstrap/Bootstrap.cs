using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Bird;
using UnityEngine;
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
        private IDataProvider _dataProvider;
        private IPlayerProgress _playerProgress;

        [Inject]
        public void Constructor(IDataProvider dataProvider, IPlayerProgress playerProgress, IStateMachine stateMachine,
            IStateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;

            _playerProgress.ClearData();
            Initialize(); //move to start in bootstrap scene.
        }

        private void Initialize()
        {
            InitializeStateMachine();
            InitializeDataProvider();
            InitializePlayerProgress();

            //Application.targetFrameRate = 60;
            
            Application.targetFrameRate = 100;
        }

        private void InitializePlayerProgress()
            => _playerProgress.Initialize(DefaultProgressData);

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<MenuLoadingState>(),
                _stateFactory.Create<MenuState>(),
                _stateFactory.Create<LevelLoadingState>(),
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
                GrassStaticData);
        }
    }
}