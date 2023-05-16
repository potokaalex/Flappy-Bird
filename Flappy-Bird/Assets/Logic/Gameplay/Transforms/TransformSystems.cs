using Entitas;

namespace FlappyBird.Gameplay.Transforms
{
    public class TransformSystems : Systems
    {
        public TransformSystems(LevelContext context)
        {
            base.Add(new PositionSystem(context));
            base.Add(new HorizontalVelocitySystem(context));
            base.Add(new VerticalVelocitySystem(context));
            base.Add(new RotationVelocitySystem(context));
            base.Add(new RotationSystem(context));
        }
    }
}