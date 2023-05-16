using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class RemoveSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _pipes;
        private readonly DeltaTime _deltaTime;

        public RemoveSystem(LevelContext context, DeltaTime deltaTime)
        {
            _pipes = context.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Pipes, LevelMatcher.Active));

            _deltaTime = deltaTime;
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
            => entity.lifetime.TimeToRemove -= _deltaTime.Value;

        private void Disactive(LevelEntity entity)
            => entity.isActive = false;
    }
}