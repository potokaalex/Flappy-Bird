namespace FlappyBird.Gameplay.Pipes
{
    public class PipesSystems : Feature
    {
        public PipesSystems(LevelContext contexts, PipesConfiguration config, DeltaTime deltaTime)
        {
            base.Add(new InitializationSystem(contexts, config));
            base.Add(new RemoveSystem(contexts, deltaTime));
            base.Add(new SpawnSystem(contexts, deltaTime));
            base.Add(new CleanupSystem(contexts));
        }
    }
}