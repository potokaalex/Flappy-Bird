using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.PreGameOver
{
    public class PreGameOverSystems : Feature, ISwitchableSystem
    {
        public PreGameOverSystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
            => base.Add(CreateSystems(contexts, gameLoop, stateMachine));
        
        public void Start(IGameLoop gameLoop)
        {
            ActivateReactiveSystems();
            gameLoop.OnFixedUpdate += Execute;
        }

        public void Stop(IGameLoop gameLoop)
        {
            DeactivateReactiveSystems();
            gameLoop.OnFixedUpdate -= Execute;
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