using FlappyBird.Gameplay.Transforms;
using FlappyBird.Gameplay.Collision;
using FlappyBird.Gameplay.GameOver;
using FlappyBird.Gameplay.Input;
using FlappyBird.Gameplay.Bird;
using FlappyBird.Extensions;
using Entitas;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class LevelEcs
    {
        private Contexts _contexts;
        private BreakableSystems _physicsSystems;//fixedUpdatable
        private Systems _graphicsSystems;//updatable
        private DataProvider _data;
        private IStateMachine _stateMachine;
        private IGameLoop _gameLoop;

        public LevelEcs(IStateMachine stateMachine, IGameLoop gameLoop, DataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
            _data = dataProvider;

            _contexts = new();
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
                .Add(new BirdSystems(_contexts, _data.BirdConfiguration, _gameLoop.FixedDeltaTime))
                .Add(new GameOverSystem(_contexts.input, _physicsSystems,
                    _data.LevelLoadingConfiguration, _stateMachine))

                //.Add(new TestSystem(_contexts))

                //pipes

                .Add(new TransformSystems(_contexts.level, _gameLoop.FixedDeltaTime))
                .Add(new CollisionCleanupSystem(_contexts.level))
                .Add(new InputCleanupSystem(_contexts.input));
        }

        private void PhysicsUpdate()
        {
            _physicsSystems.Execute();
        }

        private void GraphicsUpdate()
        {
            _graphicsSystems.Execute();
        }
    }
}
