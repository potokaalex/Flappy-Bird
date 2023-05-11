using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Level]
    public class VerticalVelocityClampComponent : IComponent
    {
        public float MinValue;
        public float MaxValue;
    }
}
