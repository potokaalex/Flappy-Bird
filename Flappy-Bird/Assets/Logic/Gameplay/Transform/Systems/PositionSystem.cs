using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class PositionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _movables;

        public PositionSystem(Contexts contexts)
        {
            _movables = contexts.game.GetGroup(
                GameMatcher.AllOf(GameMatcher.LinkToGameObject, GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
                movable.linkToGameObject.GameObject.transform.position = movable.position.Value;
        }
    }
}
