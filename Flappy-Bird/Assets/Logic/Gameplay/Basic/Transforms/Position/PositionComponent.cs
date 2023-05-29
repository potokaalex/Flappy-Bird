using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    [Level]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}
