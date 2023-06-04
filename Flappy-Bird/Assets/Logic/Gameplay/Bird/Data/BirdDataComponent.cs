using Entitas.CodeGeneration.Attributes;
using UnityEngine.InputSystem;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Input, Unique]
    public class BirdDataComponent : IComponent
    {
        public InputAction FlyUpAction;
        public float FlyUpVelocity;
    }
}