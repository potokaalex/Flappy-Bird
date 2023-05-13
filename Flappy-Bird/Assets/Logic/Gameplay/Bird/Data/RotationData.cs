using System;

namespace FlappyBird.Gameplay.Bird
{
    [Serializable]
    public struct RotationData
    {
        public float ClockwiseVelocity;
        public float CounterClockwiseVelocity;
        public float MinAngle;
        public float MaxAngle;
    }
}