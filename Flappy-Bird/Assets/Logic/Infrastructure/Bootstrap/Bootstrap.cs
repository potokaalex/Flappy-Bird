using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IGameLoop _gameLoop;
        private DataProvider _data;

        [Inject]
        public void Constructor(DataProvider dataProvider, IStateMachine stateMachine,
            IStateFactory stateFactory, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _gameLoop = gameLoop;
            _data = dataProvider;

            Initialize(); //move to start in bootstrap scene.
        }

        private void Initialize()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<SceneLoadingState>(),
                _stateFactory.Create<PreGameplayState>(),
                _stateFactory.Create<GameplayState>(),
                _stateFactory.Create<PauseState>(),
                _stateFactory.Create<GameOverState>());
        }
    }
}