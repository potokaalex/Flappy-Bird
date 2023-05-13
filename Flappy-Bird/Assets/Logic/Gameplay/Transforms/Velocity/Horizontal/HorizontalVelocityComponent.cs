using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    [Level]
    public class HorizontalVelocityComponent : IComponent
    {
        public float Value;
    }
}
