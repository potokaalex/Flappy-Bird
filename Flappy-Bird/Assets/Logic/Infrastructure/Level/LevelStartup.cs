using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private LevelStateConfiguration _configuration;

        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }

        private void Start()
        {
            InitializeStateMachine();

            _stateMachine.SwitchTo(typeof(LevelState), _configuration);
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<LevelState>(),
                _stateFactory.Create<LoadingState>());
        }
    }
}
