namespace FlappyBird.Gameplay.Pipes
{
    public class PipesSystems : Feature
    {
        public PipesSystems(LevelContext contexts, PipesConfiguration config)
        {
            base.Add(new InitializationSystem(contexts, config));
            base.Add(new RemoveSystem(contexts));
            base.Add(new SpawnSystem(contexts));
            base.Add(new CleanupSystem(contexts));
        }
    }
}