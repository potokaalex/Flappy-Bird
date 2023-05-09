using FlappyBird.Gameplay.Transforms;
using FlappyBird.Gameplay.Collision;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Input;
using FlappyBird.Gameplay.Bird;
using FlappyBird.StateMachine;
using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Infrastructure
{
    public class LevelEcs
    {
        private GameLoop _gameLoop;
        private Contexts _contexts;
        private DataProvider _data;
        private IStateMachine _stateMachine;
        private BreakableSystems _physicsSystems;
        private Systems _graphicsSystems;

        public LevelEcs(GameLoop gameLoop, DataProvider dataProvider, IStateMachine stateMachine)
        {
            _contexts = new Contexts();

            _gameLoop = gameLoop;
            _data = dataProvider;
            _stateMachine = stateMachine;

            CreateSystems();
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

        private void CreateSystems()
        {
            _physicsSystems = new();
            _graphicsSystems = new();

            _physicsSystems
                .Add(new InputSystems(_contexts.input))
                .Add(new BirdSystems(_contexts, _data.BirdConfiguration, _gameLoop.FixedDeltaTime))
                .Add(new GameOverSystem(_contexts.level, _physicsSystems,
                    _data.LevelLoadingConfiguration, _stateMachine))

                .Add(new TestSystem(_contexts))

                //pipes

                .Add(new TransformSystems(_contexts.level, _gameLoop.FixedDeltaTime))
                .Add(new CollisionCleanupSystem(_contexts.level));
        }

        private void PhysicsUpdate()
        {
            _physicsSystems.Execute();
                
            //UnityEngine.Debug.Log(_data.BirdConfiguration.FlyUpAction.enabled);
        }

        private void GraphicsUpdate()
        {
            _graphicsSystems.Execute();
        }
    }
}
