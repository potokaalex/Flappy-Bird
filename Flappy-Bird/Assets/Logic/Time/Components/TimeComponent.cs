using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace FlappyBird.Gameplay.Time
{
    [Level, Unique]
    public class TimeComponent : IComponent
    {
        public float DeltaTime;
    }
}