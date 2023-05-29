using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    [Input]
    public class CollisionComponent : IComponent
    {
        public Collision2D Info;
    }
}