using FlappyBird.Gameplay.Transforms;
using FlappyBird.Gameplay.Collision;
using FlappyBird.Gameplay.Input;
using FlappyBird.Gameplay.Bird;
using Entitas;
using FlappyBird.StateMachine;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Extensions;

namespace FlappyBird.Infrastructure
{
    public class LevelEcs
    {
        private GameLoop _gameLoop;
        private Contexts _contexts;
        private DataProvider _data;
        private BreakableSystems _physicsSystems;
        private Systems _graphicsSystems;

        public LevelEcs(GameLoop gameLoop, DataProvider dataProvider, IStateMachine stateMachine)
        {
            _gameLoop = gameLoop;
            _contexts = new Contexts();
            _data = dataProvider;

            CreateUniqueEntities();
            CreateSystems(stateMachine);
        }

        public void Initialize()
        {
            _physicsSystems.Initialize();
            _graphicsSystems.Initialize();

            _gameLoop.OnFixedUpdate += PhysicsUpdate;
            _gameLoop.OnUpdate += GraphicsUpdate;
        }

        public void Cleanup()
        {
            _physicsSystems.Cleanup();
            _graphicsSystems.Cleanup();

            _gameLoop.OnFixedUpdate -= PhysicsUpdate;
            _gameLoop.OnUpdate -= GraphicsUpdate;
        }

        private void CreateUniqueEntities()
        {
            _contexts.level.isBird = true;
            _contexts.input.isInput = true;
        }

        private void CreateSystems(IStateMachine stateMachine)
        {
            _graphicsSystems = new();
            _physicsSystems = new();

            _physicsSystems
                .Add(new BirdSystems(_contexts, _data.BirdConfiguration, _gameLoop.FixedDeltaTime))
                .Add(new GameOverSystem(_contexts.level, _physicsSystems,_data.LevelLoadingConfiguration, stateMachine))
                //pipes
                .Add(new TransformSystems(_contexts.level, _gameLoop.FixedDeltaTime))
                .Add(new CollisionCleanupSystem(_contexts.level))
                .Add(new InputCleanupSystem(_contexts.input.inputEntity));
        }

        private void PhysicsUpdate()
        {
            _physicsSystems.Execute();
        }

        private void GraphicsUpdate()
        {

        }
    }
}
