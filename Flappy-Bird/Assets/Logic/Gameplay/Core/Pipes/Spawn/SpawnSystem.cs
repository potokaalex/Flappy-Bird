using Entitas;

namespace FlappyBird.Gameplay.Core.Pipes
{
    public class SpawnSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;
        private readonly IGroup<LevelEntity> _pipes;

        public SpawnSystem(LevelContext levelContext, InputContext inputContext)
        {
            _inputContext = inputContext;
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
            => _inputContext.pipesData.TimeToSpawn <= 0;

        private void SetTimeToSpawn()
            => _inputContext.pipesData.TimeToSpawn = _inputContext.pipesData.SpawnRate;

        private void ReduceTimeToSpawn()
            => _inputContext.pipesData.TimeToSpawn -= _inputContext.time.DeltaTime;

        private void Spawn()
        {
            if (_pipes.count > 0)
                Active(_pipes.GetEntities()[0]);
            else
                _inputContext.pipesData.Factory.Create();
        }

        private void Active(LevelEntity entity)
        {
            _inputContext.pipesData.Factory.ResetPosition(entity);

            entity.lifetime.TimeToRemove = _inputContext.pipesData.RemoveRate;
            entity.isActive = true;
        }
    }
}