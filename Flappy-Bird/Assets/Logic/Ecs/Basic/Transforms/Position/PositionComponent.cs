using UnityEngine;
using Entitas;

namespace FlappyBird.Ecs.Basic.Transforms
{
    [Level]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}
