using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Bird;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    public class CoreSystems : GameplaySystems
    {
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;

        public CoreSystems(Contexts contexts, PlayerProgress progress, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _contexts = contexts;
            _gameLoop = gameLoop;

            base.Add(CreateSystems(contexts, progress, stateMachine, gameLoop));
            DeactivateReactiveSystems();
        }

        public override void Start()
        {
            _contexts.input.birdData.FlyUpAction.Enable();

            ActivateReactiveSystems();
            _gameLoop.OnFixedUpdate += base.Execute;
        }

        public override void Stop()
        {
            _contexts.input.birdData.FlyUpAction.Disable();

            DeactivateReactiveSystems();
            _gameLoop.OnFixedUpdate -= base.Execute;
        }

        private Systems CreateSystems(Contexts contexts, PlayerProgress progress,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            var systems = new Systems();

            base.Add(new BirdSystems(contexts, progress));
            base.Add(new PipesSystems(contexts, progress));
            base.Add(new GameOverCheckSystem(stateMachine, contexts.input));
            base.Add(new CommonSystems(contexts, gameLoop));

            return systems;
        }
    }
}