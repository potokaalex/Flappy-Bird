using Entitas;

namespace FlappyBird.Ecs.Basic.Time
{
    public class UpdateSystem : IExecuteSystem
    {
        private readonly InputContext _context;
        private readonly DeltaTime _deltaTime;

        public UpdateSystem(InputContext context, DeltaTime deltaTime)
        {
            _context = context;
            _deltaTime = deltaTime;
        }

        public void Execute()
            => _context.SetTime(_deltaTime.Value);
    }
}