using UnityEngine.InputSystem;
using System;

namespace FlappyBird.Gameplay.Bird
{
    [Serializable]
    public struct FlyUpData
    {
        public InputAction Action;
        public float Velocity;
        public float MinVelocity;
        public float MaxVelocity;
    }
}