using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.PreGameplay
{
    public class PreGameplaySystems : GameplaySystems
    {
        private readonly Contexts _contexts;

        public PreGameplaySystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop) : base(gameLoop)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, gameLoop, stateMachine));
        }

        public override void Start()
        {
            base.Start();
            _contexts.input.birdData.FlyUpAction.Enable();
        }

        public override void Stop()
        {
            base.Stop();
            _contexts.input.birdData.FlyUpAction.Disable();
        }

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop, IStateMachine stateMachine)
        {
            var systems = new Systems();

            systems.Add(new GrassAnimationSystem(contexts.input));
            systems.Add(new TimeUpdateSystem(_contexts.input, gameLoop.FixedDeltaTime));
            systems.Add(new InputSystem(contexts.input));
            systems.Add(new GameplayStartStateSystem(stateMachine, contexts.input));
            systems.Add(new EventCleanupSystem(contexts.input));

            return systems;
        }
    }
}