using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;

        public RotationSystem(LevelContext context)
            => _birdEntities = context.GetGroup(LevelMatcher.Bird);

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                Rotate(entity);
        }

        private void Rotate(LevelEntity bird)
        {
            if (IsFly(bird))
                bird.rotationVelocity.Value = bird.birdData.ClockwiseAngularVelocity;
            else if (IsFall(bird))
                bird.rotationVelocity.Value = bird.birdData.CounterClockwiseAngularVelocity;
        }

        private bool IsFly(LevelEntity bird)
            => bird.verticalVelocity.Value > 0;

        private bool IsFall(LevelEntity bird)
            => bird.verticalVelocity.Value < 0;
    }
}

/*
if (velocity.y > 0)//взлетаем
{
    rotation += 600 * Time.fixedDeltaTime;

    if (rotation > 20)
    {
        rotation = 20;
    }
}

if (isFalling() || !isAlive)//падаем
{
    rotation -= 480 * Time.fixedDeltaTime;

    if (rotation < -90)
    {
        rotation = -90;
    }
}
*/