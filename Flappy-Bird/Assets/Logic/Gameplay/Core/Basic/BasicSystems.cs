using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class BasicSystems : GameplaySystems
    {
        private readonly IGameLoop _gameLoop;
        private readonly Contexts _contexts;

        public BasicSystems(Contexts contexts, IGameLoop gameLoop)
        {
            _contexts = contexts;
            _gameLoop = gameLoop;

            base.Add(CreateSystems(contexts, gameLoop));
            DeactivateReactiveSystems();
        }

        public override void Start()
        {
            ActivateReactiveSystems();
            _gameLoop.OnLateFixedUpdate += base.Execute;
        }

        public override void Stop()
        {
            DeactivateReactiveSystems();
            _gameLoop.OnLateFixedUpdate -= base.Execute;
        }

        public override void Initialize()
        {
            CreateEntities();
            base.Initialize();
        }

        public override void Cleanup()
        {
            base.Cleanup();
            RemoveEntities();
        }

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop)
        {
            var systems = new Systems();

            systems.Add(new GravitySystem(contexts.level, contexts.input));
            systems.Add(new TransformSystems(contexts));
            systems.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));
            systems.Add(new EventCleanupSystem(contexts.input));

            return systems;
        }

        private void CreateEntities()
            => _contexts.input.SetTime(_gameLoop.FixedDeltaTime.Value);

        private void RemoveEntities()
            => _contexts.input.RemoveTime();
    }
}