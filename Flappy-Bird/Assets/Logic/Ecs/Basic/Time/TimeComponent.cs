using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Ecs.Basic.Time
{
    [Input, Unique]
    public class TimeComponent : IComponent
    {
        public float DeltaTime;
    }
}