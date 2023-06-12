using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IGameLoop _gameLoop;
        private IDataProvider _dataProvider;

        [Inject]
        public void Constructor(IDataProvider dataProvider, IStateMachine stateMachine,
            IStateFactory stateFactory, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _gameLoop = gameLoop;
            _dataProvider = dataProvider;

            Initialize(); //move to start in bootstrap scene.
        }

        private void Initialize()
        {
            InitializeStateMachine();
            InitializeDataProvider();
        }

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
                new PlayerProgress(),
                new GameOverStateConfiguration());
        }
    }
}