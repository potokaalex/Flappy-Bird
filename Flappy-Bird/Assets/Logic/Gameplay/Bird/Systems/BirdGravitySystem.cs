using FlappyBird.Gameplay.Common;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdGravitySystem : IExecuteSystem
    {
        private LevelEntity _bird;
        private BirdConfiguration _config;
        private DeltaTime _deltaTime;

        public BirdGravitySystem(LevelContext levelContext, BirdConfiguration config, DeltaTime deltaTime)
        {
            _bird = levelContext.birdEntity;
            _config = config;
            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            var velocity = _bird.velocity.Value.y - _config.Acceleration * _deltaTime.Value;

            if (velocity < _config.MinVelocity)
                _bird.velocity.Value.y = _config.MinVelocity;
            else
                _bird.velocity.Value.y = velocity;
        }
    }
}
