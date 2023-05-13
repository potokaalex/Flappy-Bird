using UnityEngine.InputSystem;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _gravityAcceleration;
        [SerializeField] private FlyUpData _flyUp;
        [SerializeField] private RotationData _rotation;

        private Vector2 _spawnPoint; // ?

        public void Initialize(
            Vector2 spawnPoint,
            InputAction flyUpAction = default,
            GameObject boidPrefab = default) // ?
        {
            _spawnPoint = spawnPoint;

            if (flyUpAction != default)
                _flyUp.Action = flyUpAction;

            if (boidPrefab != default)
                _prefab = boidPrefab;
        }

        public GameObject Prefab => _prefab;

        public Vector2 SpawnPoint => _spawnPoint;

        public FlyUpData FlyUp => _flyUp;

        public RotationData Rotation => _rotation;

        public float GravityAcceleration => _gravityAcceleration;
    }
}