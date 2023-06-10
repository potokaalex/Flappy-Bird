using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    [Level]
    public class BirdAnimationsComponent : IComponent
    {
        public BirdAnimator BirdAnimator;
        public float VelocityToFallDownAnimation;
    }
}