using FlappyBird.Infrastructure;
using Zenject;

namespace FlappyBird
{
    public class GlobalInitialization : IInitializable
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStateFactory _stateFactory;
        private readonly IGameLoop _gameLoop;
        private readonly DataProvider _data;

        public GlobalInitialization(DataProvider dataProvider, IStateMachine stateMachine,
            IStateFactory stateFactory, IGameLoop gameLoop)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _gameLoop = gameLoop;
            _data = dataProvider;
        }

        public void Initialize()
        {
            var ecs = new EcsBase(_data, _stateMachine, _gameLoop);

            _data.Initialize(ecs);
            InitializeStateMachine();
            ecs.BasicSystems.Initialize();
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<GameplayState>(),
                _stateFactory.Create<LoadingState>(),
                _stateFactory.Create<DefeatState>());
        }
    }
}