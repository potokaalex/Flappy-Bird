using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class GravitySystem : IExecuteSystem
    {
        private LevelEntity _bird;
        private DeltaTime _deltaTime;

        public GravitySystem(LevelContext levelContext, DeltaTime deltaTime)
        {
            _bird = levelContext.birdEntity;
            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            var velocity = _bird.velocity.Value.y - _bird.gravity.Acceleration * _deltaTime.Value;

            if (velocity < _bird.gravity.MinVelocity)
                _bird.velocity.Value.y = _bird.gravity.MinVelocity;
            else
                _bird.velocity.Value.y = velocity;
        }
    }
}
