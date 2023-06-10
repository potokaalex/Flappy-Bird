using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class TransformSystems : Systems
    {
        public TransformSystems(Contexts contexts)
        {
            base.Add(new VelocitySystem(contexts.level, contexts.input));
            base.Add(new PositionSystem(contexts.level));
        }
    }
}