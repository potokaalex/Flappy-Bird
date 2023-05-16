using UnityEngine;

namespace FlappyBird.Gameplay.Pipes
{
    [CreateAssetMenu(fileName = "New Pipes Configuration", menuName = "Configurations/Pipes")]
    public class PipesConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _velocity;

        [SerializeField] private float _spawnPositionX;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _removeRate;

        [SerializeField] private float _minPositionY;
        [SerializeField] private float _maxPositionY;
        [SerializeField] private float _maxOffsetY;

        public GameObject Prefab => _prefab;
        
        public float Velocity => _velocity;
        
        public float SpawnPositionX => _spawnPositionX;

        public float SpawnDelay => _spawnDelay;

        public float SpawnRate => _spawnRate;
        
        public float RemoveRate => _removeRate;

        public float MinPositionY => _minPositionY;

        public float MaxPositionY => _maxPositionY;

        public float MaxOffsetY => _maxOffsetY;
    }
}