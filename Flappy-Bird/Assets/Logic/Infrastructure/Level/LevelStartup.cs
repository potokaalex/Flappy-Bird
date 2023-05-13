using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private LevelStateConfiguration _configuration;

        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private void Start()
            => _stateMachine.SwitchTo(typeof(LevelState), _configuration);
    }
}