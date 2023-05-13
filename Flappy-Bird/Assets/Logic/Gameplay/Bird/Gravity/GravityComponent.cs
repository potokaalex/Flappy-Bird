using Entitas;
using System;

namespace FlappyBird.Gameplay.Bird
{
    [Serializable, Level]
    public class GravityComponent : IComponent
    {
        public float Acceleration;
    }
}