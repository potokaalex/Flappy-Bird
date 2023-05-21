using Entitas;
using System;

namespace FlappyBird.Ecs.Basic.Transforms
{
    [Serializable, Level]
    public class RotationClampComponent : IComponent
    {
        public float MinValue;
        public float MaxValue;
    }
}