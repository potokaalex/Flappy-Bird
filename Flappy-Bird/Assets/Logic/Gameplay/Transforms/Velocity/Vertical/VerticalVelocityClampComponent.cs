using Entitas;
using System;

namespace FlappyBird.Gameplay.Transforms
{
    [Serializable, Level]
    public class VerticalVelocityClampComponent : IComponent
    {
        public float MinValue;
        public float MaxValue;
    }
}
