using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    [Input, Unique]
    public class TimeComponent : IComponent
    {
        public float DeltaTime;
    }
}