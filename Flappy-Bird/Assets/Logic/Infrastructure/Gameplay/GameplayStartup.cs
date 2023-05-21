using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class GameplayStartup : MonoBehaviour
    {
        [SerializeField] private GameplayStateConfiguration _configuration;

        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start()
            => _stateMachine.SwitchTo<GameplayState, GameplayStateConfiguration>(_configuration);
    }
}