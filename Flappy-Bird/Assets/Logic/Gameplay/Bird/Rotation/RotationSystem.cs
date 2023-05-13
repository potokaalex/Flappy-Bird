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
            {
                Rotate(entity);
            }
        }

        private void Rotate(LevelEntity bird)
        {
            if (bird.verticalVelocity.Value > 0) //FlyUp
                bird.rotationVelocity.Value = bird.rotationData.ClockwiseVelocity;
            else //fall
                bird.rotationVelocity.Value = bird.rotationData.CounterClockwiseVelocity;
        }
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