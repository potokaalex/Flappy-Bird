using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class RemoveSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _pipes;
        private readonly LevelContext _context;

        public RemoveSystem(LevelContext context)
        {
            _context = context;
            _pipes = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Pipes, LevelMatcher.Active));
        }

        public void Execute()
        {
            foreach (var entity in _pipes.GetEntities())
            {
                if (IsRemoveCondition(entity))
                    Disactive(entity);
                else
                    ReduceLifetime(entity);
            }
        }

        private bool IsRemoveCondition(LevelEntity entity)
            => entity.lifetime.TimeToRemove <= 0;

        private void ReduceLifetime(LevelEntity entity)
            => entity.lifetime.TimeToRemove -= _context.time.DeltaTime;

        private void Disactive(LevelEntity entity)
            => entity.isActive = false;
    }
}