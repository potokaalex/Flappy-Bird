using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class CleanupSystem : ICleanupSystem
    {
        private readonly LevelContext _context;

        public CleanupSystem(LevelContext context)
            => _context = context;

        public void Cleanup()
            => _context.birdData.FlyUpAction.Disable();
    }
}