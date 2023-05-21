namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts)
        {
            base.Add(new InitializationSystem(contexts.level));
            base.Add(new DeathSystem(contexts.level, contexts.input));
            base.Add(new InputSystem(contexts.level, contexts.input));
            base.Add(new GravitySystem(contexts.level, contexts.input));
            base.Add(new FlyUpSystem(contexts.level, contexts.input));
            base.Add(new RotationSystem(contexts.level));
            base.Add(new CleanupSystem(contexts.level));
        }
    }
}