using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{

    [Game]
    public class Position : IComponent
    {
        public Vector2 Value;
    }
}
