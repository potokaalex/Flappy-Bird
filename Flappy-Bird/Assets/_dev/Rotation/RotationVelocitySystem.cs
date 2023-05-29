using Entitas;

namespace FlappyBird.Ecs.Gameplay
{
    public class RotationVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _rotatable;
        private readonly InputContext _inputContext;

        public RotationVelocitySystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _rotatable = levelContext.GetGroup(LevelMatcher.AllOf(
                LevelMatcher.RotationVelocity, LevelMatcher.Rotation));
        }

        public void Execute()
        {
            foreach (var rotatable in _rotatable)
                rotatable.rotation.Value += rotatable.rotationVelocity.Value * _inputContext.time.DeltaTime;
        }
    }
}