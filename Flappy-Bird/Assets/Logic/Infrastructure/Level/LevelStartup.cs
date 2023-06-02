using FlappyBird.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private PlayerProgressConfiguration _progressConfiguration;
        [SerializeField] private GameOverStateConfiguration _gameOverConfiguration;
        [SerializeField] private GameplayEcsConfiguration _gameplayEcsConfiguration;

        //
        public Transform PipesSpawnPoint;
        public GameObject BirdPrefab;
        public GameObject PipesPrefab;

        public InputAction BirdFlyUpAction;
        //

        private IStateMachine _stateMachine;
        private DataProvider _data;
        private GameplayEcs _ecs;

        [Inject]
        private void Constructor(DataProvider dataProvider, GameplayEcs ecs, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = dataProvider;
            _ecs = ecs;
        }

        private void Start()
        {
            _data.PlayerProgress.Initialize(_progressConfiguration);
            _data.PlayerProgress.GameOverStateConfiguration = _gameOverConfiguration;
            _data.PlayerProgress.BirdPrefab = BirdPrefab;
            _data.PlayerProgress.PipesPrefab = PipesPrefab;
            _data.PlayerProgress.BirdFlyUpAction = BirdFlyUpAction;
            _data.PlayerProgress.PipesSpawnPointX = PipesSpawnPoint.position.x;
            //
            _data.PlayerProgress.Score.Initialize();
            //
            _ecs.Initialize(_gameplayEcsConfiguration);
            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}