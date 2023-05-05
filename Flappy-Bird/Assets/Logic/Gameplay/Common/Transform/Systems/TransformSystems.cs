using Entitas;

namespace FlappyBird.Gameplay.Common.Transforms
{
    public class TransformSystems : Systems
    {
        public TransformSystems(LevelContext context, DeltaTime deltaTime)
        {
            Add(new PositionSystem(context));
            Add(new RotationSystem(context));
            Add(new VelocitySystem(context, deltaTime));
        }
    }
}
