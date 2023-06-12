using Entitas;

namespace FlappyBird.Gameplay.Core.Bird
{
    [Level]
    public class BirdAnimationsComponent : IComponent
    {
        public BirdAnimator BirdAnimator;
        public float VelocityToFallDownAnimation;
        public bool IsFlyUpAnimationPlaying;
    }
}