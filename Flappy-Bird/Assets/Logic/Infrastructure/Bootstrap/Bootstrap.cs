using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private DataProviderConfiguration _dataProviderConfiguration;

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

            Initialize(); //
        }

        private void Initialize()
        {
            InitializeData();
            InitializeStateMachine();
            _data.Ecs.BasicSystems.Initialize();
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<GameplayState>(),
                _stateFactory.Create<LoadingState>(),
                _stateFactory.Create<DefeatState>(),
                _stateFactory.Create<PauseState>());
        }

        private void InitializeData()//
        {
            _data.Initialize(_dataProviderConfiguration);

            _dataProviderConfiguration.PlayerProgress = new();
            _dataProviderConfiguration.Ecs = new(_data, _stateMachine, _gameLoop);
        }
    }
}