using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.PreGameplay
{
    public class PreGameplaySystems : Feature, ISwitchableSystem
    {
        private readonly Contexts _contexts;

        public PreGameplaySystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, gameLoop, stateMachine));
        }

        public void Start(IGameLoop gameLoop)
        {
            ActivateReactiveSystems();
            Initialize();
            gameLoop.OnFixedUpdate += Execute;

            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(true);
            _contexts.input.birdData.FlyUpAction.Enable();
        }

        public void Stop(IGameLoop gameLoop)
        {
            DeactivateReactiveSystems();
            Cleanup();
            gameLoop.OnFixedUpdate -= Execute;

            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(false);
            _contexts.input.birdData.FlyUpAction.Disable();
        }

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop, IStateMachine stateMachine)
        {
            var systems = new Systems();

            systems.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));
            systems.Add(new InputSystem(contexts.input));
            systems.Add(new GrassAnimationSystem(contexts.input));
            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new GameplayStartStateSystem(stateMachine, contexts.input));
            systems.Add(new EventCleanupSystem(contexts.input));

            return systems;
        }
    }
}