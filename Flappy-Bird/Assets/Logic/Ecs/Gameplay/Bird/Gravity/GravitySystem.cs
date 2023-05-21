using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class GravitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _birdEntities;
        private readonly InputContext _inputContext;
        private readonly DeltaTime _deltaTime;

        public GravitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);
        }

        public void Execute()
        {
            foreach (var entity in _birdEntities)
                ApplyVelocity(entity);
        }

        private void ApplyVelocity(LevelEntity entity)
        {
            entity.verticalVelocity.Value +=
                entity.gravity.Acceleration * _inputContext.time.DeltaTime;
        }
    }
}