namespace FlappyBird.Gameplay.Basic
{
    public class BasicSystems : Feature
    {
        private readonly Contexts _contexts;

        public BasicSystems(Contexts contexts, IGameLoop gameLoop)
        {
            _contexts = contexts;
            
            CreateEntities(contexts);
            CreateSystems(contexts, gameLoop);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
        }
        
        private void CreateEntities(Contexts contexts)
            => contexts.input.SetTime(0);

        private void RemoveEntities()
            => _contexts.input.RemoveTime();

        private void CreateSystems(Contexts contexts, IGameLoop gameLoop)
        {
            base.Add(new GravitySystem(contexts.level, contexts.input));
            base.Add(new TransformSystems(contexts));
            base.Add(new EventCleanupSystem(contexts.input));
            base.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));
        }
    }
}