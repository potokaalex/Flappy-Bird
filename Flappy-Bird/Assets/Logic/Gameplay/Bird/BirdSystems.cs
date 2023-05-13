namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, BirdConfiguration config, DeltaTime deltaTime)
        {
            Add(new BirdInitializationSystem(contexts.level, config));
            Add(new DeathSystem(contexts.input, contexts.level));
            Add(new InputSystem(contexts.level, contexts.input));

            Add(new GravitySystem(contexts.level, deltaTime));
            Add(new FlyUpSystem(contexts.level, contexts.input));

            Add(new RotationSystem(contexts.level));
            //rotation

            Add(new BirdCleanupSystem(contexts.level));
        }
    }
}