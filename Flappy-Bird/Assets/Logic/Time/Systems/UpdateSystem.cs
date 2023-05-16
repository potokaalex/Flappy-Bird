using Entitas;

namespace FlappyBird.Gameplay.Time
{
    public class UpdateSystem : IExecuteSystem
    {
        private readonly LevelContext _context;
        private readonly DeltaTime _deltaTime;

        public UpdateSystem(LevelContext context, DeltaTime deltaTime)
        {
            _context = context;
            _deltaTime = deltaTime;
        }

        public void Execute()
            => _context.time.DeltaTime = _deltaTime.Value;
    }
}