using UnityEngine;

namespace FlappyBird.Gameplay.Core.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdStaticData : ScriptableObject
    {
        [SerializeField] private float _gravityAcceleration;
        [SerializeField] private float _flyUpVelocity;
        [SerializeField] private float _velocityToFallAnimation;

        [SerializeField] private float _minVelocityY;
        [SerializeField] private float _maxVelocityY;
        [SerializeField] private float _minPositionY;
        [SerializeField] private float _maxPositionY;

        public float GravityAcceleration => _gravityAcceleration;

        public float FlyUpVelocity => _flyUpVelocity;

        public float VelocityToFallAnimation => _velocityToFallAnimation;

        public float MinVelocityY => _minVelocityY;

        public float MaxVelocityY => _maxVelocityY;

        public float MinPositionY => _minPositionY;

        public float MaxPositionY => _maxPositionY;
    }
}