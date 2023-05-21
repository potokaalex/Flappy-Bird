using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class InitializationSystem : IInitializeSystem
    {
        private readonly LevelContext _context;

        public InitializationSystem(LevelContext context) 
            => _context = context;

        public void Initialize()
            => _context.birdData.FlyUpAction.Enable();
    }
}