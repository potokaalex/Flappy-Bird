using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    [Game]
    public class Velocity : IComponent //VerticalVelocity ?
    {
        public Vector2 Value;
    }
}
