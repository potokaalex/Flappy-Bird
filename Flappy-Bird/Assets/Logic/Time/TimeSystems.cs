using Entitas;

namespace FlappyBird.Gameplay.Time
{
    public class TimeSystems : Systems
    {
        public TimeSystems(LevelContext context, DeltaTime deltaTime)
        {
            base.Add(new InitializationSystem(context));
            base.Add(new UpdateSystem(context, deltaTime));
            base.Add(new CleanupSystem(context));
        }
    }
}