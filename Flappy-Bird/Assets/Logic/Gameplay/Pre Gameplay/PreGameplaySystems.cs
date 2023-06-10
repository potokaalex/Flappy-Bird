using FlappyBird.Gameplay.Bird;
using Entitas;

namespace FlappyBird.Gameplay.PreGameplay
{
    public class PreGameplaySystems : GameplaySystems
    {
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;

        public PreGameplaySystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _contexts = contexts;
            
            base.Add(CreateSystems(contexts, stateMachine));
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

        private Systems CreateSystems(Contexts contexts, IStateMachine stateMachine)
        {
            var systems = new Systems();

            systems.Add(new InputSystem(contexts.input));
            systems.Add(new GameplayStartStateSystem(stateMachine, contexts.input));

            return systems;
        }
    }
}