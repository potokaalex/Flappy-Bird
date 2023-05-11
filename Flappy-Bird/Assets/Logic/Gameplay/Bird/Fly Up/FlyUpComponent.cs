using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Input, Unique]
    public class FlyUpComponent : IComponent
    {
        public float Velocity;
    }
}
