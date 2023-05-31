using FlappyBird.Infrastructure;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyBird
{
    public class PlayerProgress
    {
        public GameOverStateConfiguration GameOverStateConfiguration;
        public GameObject BirdPrefab;
        public GameObject PipesPrefab;
        public InputAction BirdFlyUpAction;
        public float PipesSpawnPointX;
        
        private PlayerProgressConfiguration _config;

        public Score Score { get; } = new();

        public Vector2 BirdSpawnPoint
            => _config.BirdSpawnTransform.position;

        public void Initialize(PlayerProgressConfiguration config)
        {
            _config = config;

            //save/load progress!
        }
    }
}