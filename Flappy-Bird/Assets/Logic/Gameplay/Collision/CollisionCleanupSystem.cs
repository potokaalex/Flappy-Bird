using Entitas;

namespace FlappyBird.Gameplay.Collision
{
    public class CollisionCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private IGroup<LevelEntity> _group;

        public CollisionCleanupSystem(LevelContext context)
            => _group = context.GetGroup(LevelMatcher.Collision);

        public void Execute()
            => Cleanup();

        public void Cleanup()
        {
            foreach (var entity in _group.GetEntities())
                entity.isCollision = false;
        }
    }
}
