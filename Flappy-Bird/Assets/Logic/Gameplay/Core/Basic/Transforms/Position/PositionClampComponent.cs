using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Basic
{
    [Serializable, Level]
    public class PositionClampComponent : IComponent
    {
        public Vector2 MinValue;
        public Vector2 MaxValue;
    }
}