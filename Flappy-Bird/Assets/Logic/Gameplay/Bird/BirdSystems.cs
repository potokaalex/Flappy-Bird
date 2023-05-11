namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, BirdConfiguration config, DeltaTime deltaTime)
        {
            Add(new BirdInitializationSystem(contexts.level, config));
            Add(new DeathSystem(contexts.level));
            Add(new InputSystem(contexts.input, config));
            Add(new GravitySystem(contexts.level, deltaTime));
            Add(new FlyUpSystem(contexts.level, contexts.input));

            //rotation

            Add(new VerticalVelocitySystem(contexts.level, deltaTime));
            Add(new BirdCleanupSystem(contexts.level, config));
        }
    }
}
