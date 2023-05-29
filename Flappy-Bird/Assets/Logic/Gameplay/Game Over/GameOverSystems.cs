using Entitas;
using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Ecs.Gameplay.Pipes;

namespace FlappyBird.Ecs.Defeat
{
    public class GameOverSystems : Feature
    {
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public GameOverSystems(Contexts contexts, BirdSystems birdSystems, PipesSystems pipesSystems,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            base.Add(CreateSystems(contexts, birdSystems, pipesSystems, stateMachine));
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

        private Systems CreateSystems(Contexts contexts, BirdSystems birdSystems, PipesSystems pipesSystems,
            IStateMachine stateMachine)
        {
            return new Systems()
                .Add(new GameOverSystem(contexts.level, contexts.input, birdSystems, pipesSystems, stateMachine));
        }
    }
}