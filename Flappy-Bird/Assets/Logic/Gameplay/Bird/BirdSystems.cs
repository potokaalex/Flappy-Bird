namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, BirdConfiguration config, DeltaTime deltaTime)
        {
            base.Add(new InitializationSystem(contexts.level, config));
            
            base.Add(new DeathSystem(contexts.input, contexts.level));
            base.Add(new InputSystem(contexts.level, contexts.input));
            base.Add(new GravitySystem(contexts.level, deltaTime));
            base.Add(new FlyUpSystem(contexts.level, contexts.input));
            base.Add(new RotationSystem(contexts.level));
            
            base.Add(new CleanupSystem(contexts.level));
        }
    }
}