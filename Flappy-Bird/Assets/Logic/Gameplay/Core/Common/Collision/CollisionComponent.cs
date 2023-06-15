using Entitas;

namespace FlappyBird.Gameplay.Core
{
    [Input]
    public class CollisionComponent : IComponent
    {
        public CollisionInfo Info;
    }
}