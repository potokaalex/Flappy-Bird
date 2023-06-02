using UnityEngine;
using Zenject;

namespace FlappyBird
{
    public class SceneLoadingButton : ButtonBase
    {
        [SerializeField] private SceneLoadingConfiguration _configuration;

        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private protected override void OnClick()
            => _stateMachine.SwitchTo<SceneLoadingState, SceneLoadingConfiguration>(_configuration);
    }
}