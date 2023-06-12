using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class PreGameOverSystems : GameplaySystems
    {
        private readonly IGameLoop _gameLoop;

        public PreGameOverSystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;

            base.Add(CreateSystems(contexts, gameLoop, stateMachine));
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

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop, IStateMachine stateMachine)
        {
            var systems = new Systems();

            systems.Add(new RebuildSystem(contexts.level));
            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new GravitySystem(contexts.level, contexts.input));
            systems.Add(new TransformSystems(contexts));
            systems.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));
            systems.Add(new GameOverStartStateSystem(stateMachine, contexts.input));

            return systems;
        }
    }
}