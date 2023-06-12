using Entitas;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class AnimationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;
        private readonly InputContext _inputContext;
        private bool _isFlyUpAnimationPlaying;

        public AnimationSystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                Animate(entity);
        }

        private void Animate(LevelEntity bird)
        {
            if (IsFlyUp())
            {
                bird.birdAnimations.BirdAnimator.PlayFlyUp();
                bird.birdAnimations.IsFlyUpAnimationPlaying = true;
            }
            else if (IsFallDown(bird))
            {
                bird.birdAnimations.BirdAnimator.PlayFallDown();
                bird.birdAnimations.IsFlyUpAnimationPlaying = false;
            }
        }

        private bool IsFlyUp()
            => _inputContext.isFlyUp;

        private bool IsFallDown(LevelEntity bird)
            => bird.velocity.Value.y <= bird.birdAnimations.VelocityToFallDownAnimation &&
               bird.birdAnimations.IsFlyUpAnimationPlaying;
    }
}