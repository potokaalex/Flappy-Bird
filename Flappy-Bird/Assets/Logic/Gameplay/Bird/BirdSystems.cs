using Entitas;
using FlappyBird.Ecs.Basic.Score;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        private readonly Contexts _contexts;
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public BirdSystems(Contexts contexts, DataProvider data, IGameLoop gameLoop)
        {
            _data = data;
            base.Add(CreateSystems(contexts));
            _contexts = contexts;

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
                .Add(new InitializationSystem(contexts.level))
                .Add(new InputSystem(contexts.level, contexts.input))
                .Add(new FlyUpSystem(contexts.level, contexts.input))
                .Add(new RotationSystem(contexts.level))
                .Add(new CollisionSystem(contexts.input))
                //.Add(new GameOverSystem(contexts.level,contexts.input, this))
                .Add(new ScoreSystem(contexts.input, _data.PlayerProgress.Score))
                .Add(new CleanupSystem(contexts.level));
        }
    }
}