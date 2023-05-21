using Entitas;
using System;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    [Serializable, Level]
    public class GravityComponent : IComponent
    {
        public float Acceleration;
    }
}