using Entitas;

namespace FlappyBird.Ecs.Gameplay.Pipes
{
    public class SpawnSystem : IExecuteSystem
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;
        private readonly IGroup<LevelEntity> _pipes;

        public SpawnSystem(LevelContext levelContext,InputContext inputContext)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _pipes = levelContext.GetGroup(
                LevelMatcher.AllOf(LevelMatcher.Pipes).NoneOf(LevelMatcher.Active));
        }

        public void Execute()
        {
            if (_inputContext.isGameOver)
                return;
            
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
            => _levelContext.pipesData.TimeToSpawn -= _inputContext.time.DeltaTime;

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