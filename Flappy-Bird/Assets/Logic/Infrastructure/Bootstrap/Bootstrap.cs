using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        public BirdStaticData BirdStaticData;
        public PipesStaticData PipesStaticData;
        public GrassStaticData GrassStaticData;

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
                BirdStaticData,
                PipesStaticData,
                GrassStaticData,
                new ProgressData(),
                new GameOverStateConfiguration());
        }
    }
}