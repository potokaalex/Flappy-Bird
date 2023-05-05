using Entitas;

namespace FlappyBird.Gameplay.Common.Collision
{
    public class CollisionCleanupSystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _group;

        public CollisionCleanupSystem(LevelContext context)
            => _group = context.GetGroup(LevelMatcher.Collision);

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
                entity.isCollision = false;
        }
    }
}
