using Entitas;
using System;

namespace FlappyBird.Gameplay.Basic
{
    [Serializable, Level]
    public class GravityComponent : IComponent
    {
        public float Acceleration;
    }
}