using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdConfiguration : ScriptableObject
    {
        [SerializeField] private float _gravityAcceleration;
        [SerializeField] private float _flyUpVelocity;
        [SerializeField] private float _minVelocity;
        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;

        //
        public float VelocityToFallAnimation;//-3.3

        public float MinPositionY;
        public float MaxPositionY;
        //

        public float GravityAcceleration => _gravityAcceleration;

        public float FlyUpVelocity => _flyUpVelocity;
        
        public float MinVelocity => _minVelocity;

        public float MaxVelocity => _maxVelocity;

        public float MinAngle => _minAngle;

        public float MaxAngle => _maxAngle;
    }
}