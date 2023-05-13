using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class TransformSystems : Systems
    {
        public TransformSystems(LevelContext context, DeltaTime deltaTime)
        {
            Add(new PositionSystem(context));
            Add(new HorizontalVelocitySystem(context, deltaTime));
            Add(new VerticalVelocitySystem(context, deltaTime));
            Add(new RotationVelocitySystem(context, deltaTime));
            Add(new RotationSystem(context));
        }
    }
}
