using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class EventCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<InputEntity> _events;

        public EventCleanupSystem(InputContext context) 
            => _events = context.GetGroup(InputMatcher.Event);

        public void Execute()
        {
            foreach (var @event in _events.GetEntities())
                @event.Destroy();
        }

        public void Cleanup() 
            => Execute();
    }
}