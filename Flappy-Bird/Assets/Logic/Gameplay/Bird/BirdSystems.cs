using FlappyBird.Extensions;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, DeltaTime deltaTime)
        {
            var config = contexts.configs.birdConfiguration;

            Add(new InputSystem(contexts.input.inputEntity, config.FlyUpAction));
            Add(new DeathSystem(contexts.level));
            Add(new GravitySystem(contexts.level, deltaTime));
            //move
        }
    }
}
