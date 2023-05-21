using Entitas;

namespace FlappyBird.Ecs.Basic.Time
{
    public class TimeSystems : Systems
    {
        public TimeSystems(InputContext context, DeltaTime deltaTime)
        {
            base.Add(new InitializationSystem(context, deltaTime));
            base.Add(new UpdateSystem(context, deltaTime));
        }
    }
}