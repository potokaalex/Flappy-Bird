using UnityEngine;

namespace FlappyBird.Gameplay.Core.Pipes
{
    [CreateAssetMenu(fileName = "New Pipes Configuration", menuName = "Configurations/Pipes")]
    public class PipesConfiguration : ScriptableObject
    {
        [SerializeField] private float _velocity;

        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _removeRate;

        [SerializeField] private float _minPositionY;
        [SerializeField] private float _maxPositionY;
        [SerializeField] private float _maxOffsetY;

        public float Velocity => _velocity;

        public float SpawnDelay => _spawnDelay;

        public float SpawnRate => _spawnRate;

        public float RemoveRate => _removeRate;

        public float MinPositionY => _minPositionY;

        public float MaxPositionY => _maxPositionY;

        public float MaxOffsetY => _maxOffsetY;
    }
}