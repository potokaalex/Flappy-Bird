using Entitas;

namespace FlappyBird.Ecs.Basic.Time
{
    public class InitializationSystem : IInitializeSystem
    {
        private readonly InputContext _context;
        private readonly DeltaTime _deltaTime;

        public InitializationSystem(InputContext context, DeltaTime deltaTime)
        {
            _context = context;
            _deltaTime = deltaTime;
        }

        public void Initialize()
            => _context.SetTime(_deltaTime.Value);
    }
}