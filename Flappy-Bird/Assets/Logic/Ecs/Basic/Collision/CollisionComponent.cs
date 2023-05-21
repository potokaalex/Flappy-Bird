using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Entitas;

namespace FlappyBird.Ecs.Basic.Collision
{
    [Input, Unique]
    public class CollisionComponent : IComponent
    {
        public Collision2D Info;
    }
}