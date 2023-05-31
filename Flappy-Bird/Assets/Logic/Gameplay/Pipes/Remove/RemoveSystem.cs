using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class RemoveSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _pipes;
        private readonly InputContext _inputContext;

        public RemoveSystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
            _pipes = levelContext.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Pipes, LevelMatcher.Active));
        }

        public void Execute()
        {
            if (_inputContext.isGameOver)
                return;

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
            => entity.lifetime.TimeToRemove -= _inputContext.time.DeltaTime;

        private void Disactive(LevelEntity entity)
            => entity.isActive = false;
    }
}