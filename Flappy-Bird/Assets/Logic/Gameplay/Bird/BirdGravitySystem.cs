using Entitas;
using FlappyBird.Common;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdGravitySystem : IExecuteSystem
    {
        private GameEntity _bird;
        private BirdConfiguration _config;
        private DeltaTime _deltaTime;

        public BirdGravitySystem(Contexts contexts, DeltaTime deltaTime)
        {
            _bird = contexts.game.birdEntity;
            _config = contexts.config.birdConfiguration;
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
