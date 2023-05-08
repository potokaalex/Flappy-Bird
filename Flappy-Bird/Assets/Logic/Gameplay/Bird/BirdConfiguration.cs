using UnityEngine.InputSystem;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdConfiguration : ScriptableObject
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _minVelocity;

        public void Initialize(InputAction flyUpAction, GameObject boidPrefab, Vector2 spawnPoint)
        {
            FlyUpAction = flyUpAction;
            Prefab = boidPrefab;
            SpawnPoint = spawnPoint;
        }

        public GameObject Prefab { get; private set; }

        public InputAction FlyUpAction { get; private set; }

        public Vector2 SpawnPoint { get; private set; }

        public float Acceleration => _acceleration;

        public float MaxVelocity => _maxVelocity;
        
        public float MinVelocity => _minVelocity;
    }
}
