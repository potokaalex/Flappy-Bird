using FlappyBird.Gameplay;

namespace FlappyBird
{
    public class DevSystems : Feature
    {
        private readonly DataProvider _data;
        private readonly IGameLoop _gameLoop;

        public DevSystems(Contexts contexts, DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            CreateSystems(contexts, data, stateMachine);
            _gameLoop = gameLoop;
        }

        private void CreateSystems(Contexts contexts, DataProvider data, IStateMachine stateMachine)
        {
            base.Add(new TestSystem(contexts, data, stateMachine, _gameLoop));
            //base.Add(new RotationVelocitySystem(contexts.level, contexts.input));
        }
    }
}