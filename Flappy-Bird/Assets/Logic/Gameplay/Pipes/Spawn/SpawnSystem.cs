using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class SpawnSystem : IExecuteSystem
    {
        private readonly LevelContext _context;
        private readonly IGroup<LevelEntity> _pipes;

        public SpawnSystem(LevelContext context)
        {
            _context = context;
            _pipes = context.GetGroup(
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
            => _context.pipesData.TimeToSpawn <= 0;

        private void SetTimeToSpawn()
            => _context.pipesData.TimeToSpawn = _context.pipesData.SpawnRate;

        private void ReduceTimeToSpawn()
            => _context.pipesData.TimeToSpawn -= _context.time.DeltaTime;

        private void Spawn()
        {
            if (_pipes.count > 0)
                Active(_pipes.GetEntities()[0]);
            else
                _context.pipesData.Factory.Create();
        }

        private void Active(LevelEntity entity)
        {
            _context.pipesData.Factory.ResetPosition(entity);

            entity.lifetime.TimeToRemove = _context.pipesData.RemoveRate;
            entity.isActive = true;
        }
    }
}