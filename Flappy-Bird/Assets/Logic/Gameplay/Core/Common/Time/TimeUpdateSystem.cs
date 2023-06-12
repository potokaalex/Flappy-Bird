using Entitas;

namespace FlappyBird.Gameplay.Core
{
    public class TimeUpdateSystem : IExecuteSystem
    {
        private readonly InputContext _context;
        private readonly DeltaTime _deltaTime;

        public TimeUpdateSystem(InputContext context, DeltaTime deltaTime)
        {
            _context = context;
            _deltaTime = deltaTime;
        }

        public void Execute()
            => _context.time.DeltaTime = _deltaTime.Value;
    }
}