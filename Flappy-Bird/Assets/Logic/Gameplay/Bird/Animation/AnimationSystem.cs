using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class AnimationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;
        private bool isFlyUpAnimationPlaying;

        public AnimationSystem(LevelContext levelContext)
            => _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                Animate(entity);
        }

        private void Animate(LevelEntity bird)
        {
            if (IsFlyUp(bird))
            {
                bird.birdAnimations.BirdAnimator.PlayFlyUp();
                isFlyUpAnimationPlaying = true;
            }
            else if (IsFallDown(bird))
            {
                bird.birdAnimations.BirdAnimator.PlayFallDown();
                isFlyUpAnimationPlaying = false;
            }
        }

        private bool IsFlyUp(LevelEntity bird)
            => bird.velocity.Value.y > 0 && !isFlyUpAnimationPlaying;

        private bool IsFallDown(LevelEntity bird)
            => bird.velocity.Value.y <= bird.birdAnimations.VelocityToFallDownAnimation && isFlyUpAnimationPlaying;
    }
}