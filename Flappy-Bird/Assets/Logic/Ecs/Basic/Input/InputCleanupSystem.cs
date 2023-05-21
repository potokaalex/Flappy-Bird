using Entitas;

namespace FlappyBird.Ecs.Basic.Input
{
    public class InputCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly InputContext _context;

        public InputCleanupSystem(InputContext context)
            => _context = context;

        public void Execute()
            => Cleanup();

        public void Cleanup()
        {
            if (_context.count > 0)
            {
                foreach (var entity in _context.GetEntities())
                    entity.Destroy();
            }
        }
    }
}