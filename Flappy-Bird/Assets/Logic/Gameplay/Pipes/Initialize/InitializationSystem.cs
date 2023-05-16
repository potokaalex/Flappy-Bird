using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class InitializationSystem : IInitializeSystem
    {
        private readonly LevelContext _context;
        private readonly PipesConfiguration _config;

        public InitializationSystem(LevelContext context, PipesConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public void Initialize()
        {
            var factory = new PipesFactory(_context, _config);

            _context.SetPipesData(factory, _config.SpawnDelay,
                _config.SpawnRate, _config.RemoveRate);
        }
    }
}