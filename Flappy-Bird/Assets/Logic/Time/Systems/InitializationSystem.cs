using Entitas;

namespace FlappyBird.Gameplay.Time
{
    public class InitializationSystem : IInitializeSystem
    {
        private readonly LevelContext _context;

        public InitializationSystem(LevelContext context) 
            => _context = context;
        
        public void Initialize() 
            => _context.SetTime(0);
    }
}