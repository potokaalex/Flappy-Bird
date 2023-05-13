using Entitas.CodeGeneration.Attributes;
using UnityEngine.InputSystem;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Level, Unique]
    public struct FlyUpDataComponent : IComponent
    {
        public InputAction Action;
        public float Velocity;
    }
}