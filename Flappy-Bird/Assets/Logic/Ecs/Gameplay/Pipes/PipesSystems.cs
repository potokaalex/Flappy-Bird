namespace FlappyBird.Ecs.Gameplay.Pipes
{
    public class PipesSystems : Feature
    {
        public PipesSystems(Contexts contexts)
        {
            base.Add(new RemoveSystem(contexts.level, contexts.input));
            base.Add(new SpawnSystem(contexts.level, contexts.input));
            //base.Add(new CleanupSystem(contexts.level));
        }
    }
}