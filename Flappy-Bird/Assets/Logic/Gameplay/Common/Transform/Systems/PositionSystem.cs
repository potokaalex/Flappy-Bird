using Entitas;

namespace FlappyBird.Gameplay.Common.Transforms
{
    public class PositionSystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _movables;

        public PositionSystem(LevelContext context)
        {
            _movables = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.LinkToGameObject, LevelMatcher.Position));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
                movable.linkToGameObject.GameObject.transform.position = movable.position.Value;
        }
    }
}
