using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class MenuStartup : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine) 
            => _stateMachine = stateMachine;

        public void Start() 
            => _stateMachine.SwitchTo<MenuState>();
    }
}