using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class EventCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<InputEntity> _events;
        private readonly InputContext _context;

        public EventCleanupSystem(InputContext context)
        {
            _context = context;
            _events = context.GetGroup(InputMatcher.Event);
        }

        public void Execute()
            => Cleanup();

        public void Cleanup()
        {
            if (_context.count > 0)
            {
                foreach (var @event in _events.GetEntities())
                    @event.Destroy();
            }
        }
    }
}