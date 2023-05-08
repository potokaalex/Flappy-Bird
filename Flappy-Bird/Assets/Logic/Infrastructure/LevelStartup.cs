using FlappyBird.Gameplay.Bird;
using UnityEngine.InputSystem;
using UnityEngine;
using FlappyBird.Infrastructure;
using Zenject;
using FlappyBird.StateMachine;
using UnityEngine.SceneManagement;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private InputAction _flyUpAction;
    [SerializeField] private GameObject _birdPrefab;
    [SerializeField] private Transform _birdSpawnPoint;

    private IStateMachine _stateMachine;
    private DataProvider _dataProvider;
    private IStateFactory _stateFactory;

    [Inject]
    private void Constructor(DataProvider dataProvider, IStateFactory stateFactory, IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _dataProvider = dataProvider;
        _stateFactory = stateFactory;
    }

    private void Start()
    {
        _dataProvider.BirdConfiguration.Initialize(_flyUpAction, _birdPrefab, _birdSpawnPoint.position);
        _stateMachine.SwitchTo<LevelState>();
    }
}
