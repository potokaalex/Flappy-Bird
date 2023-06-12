using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Core
{
    [Serializable, Level]
    public class PositionClampComponent : IComponent
    {
        public Vector2 MinValue;
        public Vector2 MaxValue;
    }
}