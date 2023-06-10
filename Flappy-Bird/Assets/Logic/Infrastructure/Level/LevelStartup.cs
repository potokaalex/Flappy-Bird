using FlappyBird.Gameplay;
using FlappyBird.Gameplay.Bird;
using FlappyBird.Gameplay.Pipes;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private GameOverStateConfiguration _gameOverConfiguration;

        public BirdConfiguration BirdConfig;
        public InputAction BirdFlyUpAction;
        public GameObject BirdPrefab;
        public Transform BirdSpawnPoint;

        public PipesConfiguration PipesConfig;
        public GameObject PipesPrefab;
        public Transform PipesSpawnPoint;

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
            _data.GameOverStateConfiguration = _gameOverConfiguration;

            InitBirdData();
            InitPipesData();
            InitScore();

            _stateMachine.SwitchTo<PreGameplayState>();
        }

        private void InitBirdData()
        {
            _data.Progress.BirdData.StaticData = BirdConfig;
            _data.Progress.BirdData.BirdFlyUpAction = BirdFlyUpAction;
            _data.Progress.BirdData.BirdPrefab = BirdPrefab;
            _data.Progress.BirdData.BirdSpawnPoint = BirdSpawnPoint.position;
        }

        private void InitPipesData()
        {
            _data.Progress.PipesData.StaticData = PipesConfig;
            _data.Progress.PipesData.PipesPrefab = PipesPrefab;
            _data.Progress.PipesData.PipesSpawnPointX = PipesSpawnPoint.position.x;
        }

        private void InitScore() 
            => _data.Progress.Score._currentScore = 0;
    }
}