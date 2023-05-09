using FlappyBird.StateMachine;
using UnityEngine;
using Zenject;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _configuration;

    private IStateMachine _stateMachine;

    [Inject]
    private void Constructor(IStateMachine stateMachine)
        => _stateMachine = stateMachine;

    private void Start()
        => _stateMachine.SwitchTo(typeof(LevelState), _configuration);
}
