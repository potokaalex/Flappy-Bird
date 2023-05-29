using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class VelocityClampComponent : IComponent
    {
        public Vector2 MinValue;
        public Vector2 MaxValue;
    }
}