using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    [Input]
    public class CollisionComponent : IComponent
    {
        public Collision2D Info;
    }
}