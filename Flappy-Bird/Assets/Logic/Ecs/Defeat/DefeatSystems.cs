using Entitas;

namespace FlappyBird.Ecs.Defeat
{
    public class DefeatSystems
    {
        private readonly IGameLoop _gameLoop;
        private readonly Systems _systems;

        public DefeatSystems(Contexts contexts, DataProvider dataProvider,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _systems = CreateSystems();
        }

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }

        private Systems CreateSystems()
        {
            return default;
        }
    }
}