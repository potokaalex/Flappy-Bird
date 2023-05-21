using Entitas;

namespace FlappyBird.Ecs.Basic.Transforms
{
    public class TransformSystems : Systems
    {
        public TransformSystems(Contexts contexts)
        {
            base.Add(new PositionSystem(contexts.level));
            base.Add(new HorizontalVelocitySystem(contexts.level, contexts.input));
            base.Add(new VerticalVelocitySystem(contexts.level, contexts.input));
            base.Add(new RotationVelocitySystem(contexts.level, contexts.input));
            base.Add(new RotationSystem(contexts.level));
        }
    }
}