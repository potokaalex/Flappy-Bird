using FlappyBird.Ecs.Gameplay;
using Entitas;

namespace FlappyBird
{
    public class DevSystems : Feature
    {
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public DevSystems(Contexts contexts, DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            base.Add(CreateSystems(contexts, data, stateMachine));
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

        private Systems CreateSystems(Contexts contexts, DataProvider data, IStateMachine stateMachine)
        {
            return new Systems()
                .Add(new TestSystem(contexts, data, stateMachine, _gameLoop))
                .Add(new RotationVelocitySystem(contexts.level, contexts.input));
        }
    }
}