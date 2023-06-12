using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    [Level]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}
