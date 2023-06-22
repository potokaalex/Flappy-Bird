using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverSystems : Feature, ISwitchableSystem
    {
        public GameOverSystems(Contexts contexts, IGameLoop gameLoop)
            => base.Add(CreateSystems(contexts, gameLoop));

        public void Start(IGameLoop gameLoop)
        {
            ActivateReactiveSystems();
            Initialize();
            gameLoop.OnFixedUpdate += Execute;
        }

        public void Stop(IGameLoop gameLoop)
        {
            DeactivateReactiveSystems();
            Cleanup();
            gameLoop.OnFixedUpdate -= Execute;
        }

        private Systems CreateSystems(Contexts contexts, IGameLoop gameLoop)
        {
            var systems = new Systems();

            systems.Add(new AnimationSystem(contexts.level, contexts.input));
            systems.Add(new GravitySystem(contexts.level, contexts.input));
            systems.Add(new TransformSystems(contexts));
            systems.Add(new TimeUpdateSystem(contexts.input, gameLoop.FixedDeltaTime));

            return systems;
        }
    }
}