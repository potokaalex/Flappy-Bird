﻿using UnityEngine.InputSystem;
using FlappyBird.Gameplay;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private GameOverStateConfiguration _gameOverConfiguration;

        public BirdStaticData BirdConfig;
        public InputAction BirdFlyUpAction;
        public GameObject BirdPrefab;
        public Transform BirdSpawnPoint;

        public PipesStaticData PipesConfig;
        public GameObject PipesPrefab;
        public Transform PipesSpawnPoint;

        public GrassStaticData GrassConfig;
        public MeshRenderer GrassMesh;

        private IStateMachine _stateMachine;
        private IDataProvider _data;
        private GameplayEcs _ecs;
        private PlayerProgress _playerProgress;
        
        [Inject]
        private void Constructor(IDataProvider dataProvider, GameplayEcs ecs, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = dataProvider;
            _ecs = ecs;
        }

        private void Start()
        {
            _playerProgress = _data.Get<PlayerProgress>();
            _data.Get<GameOverStateConfiguration>().GameOverUI = _gameOverConfiguration.GameOverUI;
            _data.Get<GameOverStateConfiguration>().GameplayUI = _gameOverConfiguration.GameplayUI;

            InitBirdData();
            InitPipesData();
            InitScore();
            InitGrass();

            _stateMachine.SwitchTo<PreGameplayState>();
        }

        private void InitGrass()
        {
            _playerProgress.GrassData.StaticData = GrassConfig;
            _playerProgress.GrassData.MeshRenderer = GrassMesh;
        }

        private void InitBirdData()
        {
            _playerProgress.BirdData.StaticData = BirdConfig;
            _playerProgress.BirdData.BirdFlyUpAction = BirdFlyUpAction;
            _playerProgress.BirdData.BirdPrefab = BirdPrefab;
            _playerProgress.BirdData.BirdSpawnPoint = BirdSpawnPoint.position;
        }

        private void InitPipesData()
        {
            _playerProgress.PipesData.StaticData = PipesConfig;
            _playerProgress.PipesData.PipesPrefab = PipesPrefab;
            _playerProgress.PipesData.PipesSpawnPointX = PipesSpawnPoint.position.x;
        }

        private void InitScore() 
            => _playerProgress.Score._currentScore = 0;
    }
}