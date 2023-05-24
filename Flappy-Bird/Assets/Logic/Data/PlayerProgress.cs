using UnityEngine;

namespace FlappyBird
{
    public class PlayerProgress
    {
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