using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core.Grass
{
    [Input, Unique]
    public class GrassDataComponent : IComponent
    {
        public Material Material;
        public float ScrollVelocityY;
    }
}