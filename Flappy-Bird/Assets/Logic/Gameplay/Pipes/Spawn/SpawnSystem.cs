using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class SpawnSystem : IExecuteSystem
    {
        private readonly LevelContext _levelContext;
        private readonly DeltaTime _deltaTime;
        private readonly IGroup<LevelEntity> _pipes;

        public SpawnSystem(LevelContext levelContext, DeltaTime deltaTime)
        {
            _levelContext = levelContext;
            _deltaTime = deltaTime;

            _pipes = levelContext.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Pipes).NoneOf(LevelMatcher.Active));
        }

        public void Execute()
        {
            if (IsSpawnCondition())
            {
                Spawn();
                SetTimeToSpawn();
            }
            else
                ReduceTimeToSpawn();
        }

        private bool IsSpawnCondition()
            => _levelContext.pipesData.TimeToSpawn <= 0;

        private void SetTimeToSpawn()
            => _levelContext.pipesData.TimeToSpawn = _levelContext.pipesData.SpawnRate;

        private void ReduceTimeToSpawn()
            => _levelContext.pipesData.TimeToSpawn -= _deltaTime.Value;

        private void Spawn()
        {
            if (_pipes.count > 0)
                Active(_pipes.GetEntities()[0]);
            else
                _levelContext.pipesData.Factory.Create();
        }

        private void Active(LevelEntity entity)
        {
            _levelContext.pipesData.Factory.ResetPosition(entity);

            entity.lifetime.TimeToRemove = _levelContext.pipesData.RemoveRate;
            entity.isActive = true;
        }
    }
}