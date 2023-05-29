using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class BasicSystems : Feature
    {
        private readonly IGameLoop _gameLoop;

        public BasicSystems(Contexts contexts, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            base.Add(CreateSystems(contexts));
        }

        public override void Initialize()
        {
            base.Initialize();
            _gameLoop.OnFixedUpdate += base.Execute;
        }

        public override void Cleanup()
        {
            base.Cleanup();
            _gameLoop.OnFixedUpdate -= base.Execute;
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Systems()
                .Add(new GravitySystem(contexts.level, contexts.input))
                .Add(new TransformSystems(contexts))
                .Add(new EventCleanupSystem(contexts.input))
                .Add(new TimeUpdateSystem(contexts.input, _gameLoop.FixedDeltaTime));
        }
    }
}