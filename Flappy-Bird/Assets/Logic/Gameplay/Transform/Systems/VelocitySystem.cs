using Entitas;
using FlappyBird.Common;

namespace FlappyBird.Gameplay.Transforms
{
    public class VelocitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _movables;
        private DeltaTime _deltaTime;

        public VelocitySystem(Contexts contexts, DeltaTime deltaTime)
        {
            _movables = contexts.game.GetGroup(
                GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));

            _deltaTime = deltaTime;
        }

        public void Execute()
        {
            foreach (var movable in _movables)
                movable.position.Value += movable.velocity.Value * _deltaTime.Value;
        }
    }
}
