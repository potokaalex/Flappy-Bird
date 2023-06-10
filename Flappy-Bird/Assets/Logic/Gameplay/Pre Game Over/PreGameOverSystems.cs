using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class PreGameOverSystems : GameplaySystems
    {
        private readonly IGameLoop _gameLoop;

        public PreGameOverSystems(Contexts contexts, BirdSystems birdSystems, PipesSystems pipesSystems,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;

            base.Add(CreateSystems(contexts, birdSystems, pipesSystems, stateMachine));
            DeactivateReactiveSystems();
        }

        public override void Start()
        {
            ActivateReactiveSystems();
            _gameLoop.OnFixedUpdate += base.Execute;
        }

        public override void Stop()
        {
            DeactivateReactiveSystems();
            _gameLoop.OnFixedUpdate -= base.Execute;
        }

        private Systems CreateSystems(Contexts contexts, BirdSystems birdSystems, PipesSystems pipesSystems,
            IStateMachine stateMachine)
        {
            var systems = new Systems();

            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new RebuildSystem(contexts.level, birdSystems, pipesSystems, contexts.input));
            systems.Add(new GameOverStartStateSystem(stateMachine, contexts.input));

            return systems;
        }
    }
}