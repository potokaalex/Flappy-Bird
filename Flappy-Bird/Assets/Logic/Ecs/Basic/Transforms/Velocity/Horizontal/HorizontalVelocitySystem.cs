using Entitas;

namespace FlappyBird.Ecs.Basic.Transforms
{
    public class HorizontalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;
        private readonly InputContext _inputContext;

        public HorizontalVelocitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _movables = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.Position, LevelMatcher.HorizontalVelocity));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
            {
                movable.position.Value.x +=
                    movable.horizontalVelocity.Value * _inputContext.time.DeltaTime;
            }
        }
    }
}