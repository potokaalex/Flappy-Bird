using FlappyBird.Gameplay.Common;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, DeltaTime deltaTime)
        {
            Add(new BridCollisionSystem(contexts.level));
            Add(new BirdGravitySystem(contexts.level, contexts.configs.birdConfiguration,deltaTime));
        }
    }
}
