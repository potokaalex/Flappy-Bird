using UnityEngine;
using Entitas;

namespace FlappyBird.Ecs.Basic.Collision
{
    [Input]
    public class CollisionComponent : IComponent
    {
        public Collision2D Info;
    }
}