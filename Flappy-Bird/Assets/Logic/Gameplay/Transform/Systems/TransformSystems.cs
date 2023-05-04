using FlappyBird.Common;

namespace FlappyBird.Gameplay.Transforms
{
    public class TransformSystems : Feature
    {
        private const string FEATURE_NAME = "Transform Systems";

        public TransformSystems(Contexts contexts, DeltaTime deltaTime) : base(FEATURE_NAME)
        {
            Add(new PositionSystem(contexts));
            Add(new RotationSystem(contexts));
            Add(new VelocitySystem(contexts, deltaTime));
        }
    }
}
