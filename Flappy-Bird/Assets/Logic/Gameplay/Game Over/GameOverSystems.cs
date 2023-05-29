using Entitas;
using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Ecs.Gameplay.Pipes;

namespace FlappyBird.Ecs.Defeat
{
    public class GameOverSystems : Feature
    {
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public GameOverSystems(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            //base.Add(new GameOverSystem(contexts.level, contexts.input, birdSystems, pipesSystems, stateMachine));
        }
    }
}