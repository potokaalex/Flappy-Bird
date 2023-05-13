using Entitas;

namespace FlappyBird.Gameplay.Collision
{
    public class CollisionCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private IGroup<LevelEntity> _collisions;

        public CollisionCleanupSystem(LevelContext context)
            => _collisions = context.GetGroup(LevelMatcher.Collision);

        public void Execute()
            => Cleanup();

        public void Cleanup()
        {
            foreach (var entity in _collisions.GetEntities())
                entity.isCollision = false;
        }
    }
}
