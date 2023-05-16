using Entitas;

namespace FlappyBird.Gameplay.Time
{
    public class CleanupSystem : ICleanupSystem
    {
        private readonly LevelContext _context;

        public CleanupSystem(LevelContext context)
            => _context = context;

        public void Cleanup()
            => _context.RemoveTime();
    }
}