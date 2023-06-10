using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class GravitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _entities;
        private readonly InputContext _inputContext;

        public GravitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _entities = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Velocity, LevelMatcher.Gravity));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
                ApplyGravity(entity);
        }

        private void ApplyGravity(LevelEntity entity)
            => entity.velocity.Value.y += entity.gravity.Acceleration * _inputContext.time.DeltaTime;
    }
}