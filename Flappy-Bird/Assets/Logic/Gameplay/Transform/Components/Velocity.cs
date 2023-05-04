using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    [Game]
    public class Velocity : IComponent
    {
        public Vector2 Value;
    }
}
