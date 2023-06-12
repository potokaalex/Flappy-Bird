using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    [Input, Unique]
    public class TimeComponent : IComponent
    {
        public float DeltaTime;
    }
}