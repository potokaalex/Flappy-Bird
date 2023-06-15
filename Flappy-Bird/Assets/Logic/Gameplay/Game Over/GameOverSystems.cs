using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverSystems : GameplaySystems
    {
        public GameOverSystems(Contexts contexts, IGameLoop gameLoop) : base(gameLoop) 
            => base.Add(CreateSystems(contexts, gameLoop));

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