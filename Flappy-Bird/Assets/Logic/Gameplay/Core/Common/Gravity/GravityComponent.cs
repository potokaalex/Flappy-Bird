using Entitas;
using System;

namespace FlappyBird.Gameplay.Core
{
    [Serializable, Level]
    public class GravityComponent : IComponent
    {
        public float Acceleration;
    }
}