using Entitas.CodeGeneration.Attributes;
using UnityEngine.InputSystem;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Level, Unique]
    public class BirdDataComponent : IComponent
    {
        public InputAction FlyUpAction;
        public float FlyUpVelocity;
        public float ClockwiseAngularVelocity;
        public float CounterClockwiseAngularVelocity;
    }
}