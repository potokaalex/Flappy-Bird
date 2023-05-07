using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    [Level]
    public class VelocityComponent : IComponent
    {
        public Vector2 Value;
    }
}
