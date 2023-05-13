using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Level, Unique]
    public class RotationDataComponent : IComponent
    {
        public float CounterClockwiseVelocity;
        public float ClockwiseVelocity;
    }
}