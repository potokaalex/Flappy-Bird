using Entitas;
using UnityEngine.InputSystem;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdConfiguration : ScriptableObject //BirdsConfiguration?
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private InputAction _flyUpAction;
        [SerializeField] private float _gravityAcceleration;
        [SerializeField] private float _flyUpVelocity;
        [SerializeField] private float _clockwiseAngularVelocity;
        [SerializeField] private float _counterClockwiseAngularVelocity;
        [SerializeField] private float _minVelocity;
        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;

        private Vector2 _spawnPoint;

        public void Initialize(Vector2 spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }

        public GameObject Prefab => _prefab;

        public InputAction FlyUpAction => _flyUpAction;

        public float GravityAcceleration => _gravityAcceleration;

        public Vector2 SpawnPoint => _spawnPoint;

        public float FlyUpVelocity => _flyUpVelocity;

        public float ClockwiseAngularVelocity => _clockwiseAngularVelocity;

        public float CounterClockwiseAngularVelocity => _counterClockwiseAngularVelocity;

        public float MinVelocity => _minVelocity;

        public float MaxVelocity => _maxVelocity;

        public float MinAngle => _minAngle;

        public float MaxAngle => _maxAngle;
    }
}