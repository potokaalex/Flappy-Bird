using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    [Level]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}
