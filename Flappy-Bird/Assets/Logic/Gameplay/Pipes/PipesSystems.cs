using Entitas;

namespace FlappyBird.Ecs.Gameplay.Pipes
{
    public class PipesSystems : Feature
    {
        private readonly Contexts _contexts;
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public PipesSystems(Contexts contexts, DataProvider data, IGameLoop gameLoop)
        {
            base.Add(CreateSystems(contexts));
            _contexts = contexts;
            _data = data;
            _gameLoop = gameLoop;
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
                .Add(new RemoveSystem(contexts.level, contexts.input))
                .Add(new SpawnSystem(contexts.level, contexts.input));
        }
    }
}