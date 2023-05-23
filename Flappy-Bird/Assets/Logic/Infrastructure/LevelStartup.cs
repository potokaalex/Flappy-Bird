﻿using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private GameplayStateConfiguration _configuration;

        private IStateMachine _stateMachine;
        private DataProvider _data;

        [Inject]
        private void Constructor(IStateMachine stateMachine,DataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _data = dataProvider;
        }

        private void Start()
        {
            _data.BirdConfiguration.Initialize(_configuration.BirdSpawnPoint.position);

            _data.Ecs.CreateEntities();
            
            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}