using Entitas;
using UnityEngine;
using FlappyBird.Gameplay.Common.Transforms;
using FlappyBird.Gameplay.Bird;
using FlappyBird.Gameplay.Common.Collision;
using FlappyBird.Gameplay.Common.Input;
using UnityEngine.InputSystem;

public class LevelEcs
{
    private GameLoop _gameLoop;
    private Contexts _contexts;
    private Systems _physicsSystems;
    private Systems _graphicsSystems;

    public LevelEcs(GameLoop gameLoop)//
    {
        _gameLoop = gameLoop;
        _contexts = new Contexts();
        _physicsSystems = new();
        _graphicsSystems = new();

        _gameLoop.OnPhysicsUpdate += PhysicsUpdate;
        _gameLoop.OnGraphicsUpdate += GraphicsUpdate;
        _gameLoop.OnDispose += Dispose;
    }

    //public void InitializeEntities() { }

    public void InitializeConfigurations(BirdConfiguration birdConfiguration)
    {
        var entity = _contexts.configs.CreateEntity();

        entity.AddBirdConfiguration(birdConfiguration.SpawnPoint, birdConfiguration.Prefab,
           birdConfiguration.Acceleration, birdConfiguration.MaxVelocity, birdConfiguration.MinVelocity);
    }

    public void InitializeEntities()
    {
        var birdFactory = new BirdFactory(_contexts.level, _contexts.configs.birdConfiguration);
        birdFactory.Create();
    }

    public void InitializeSystems(InputAction birdFlyUpAction)
    {
        var inputEntity = _contexts.input.CreateEntity();
        inputEntity.isInput = true;

        birdFlyUpAction.Enable();

        _physicsSystems
            .Add(new BirdInputSystem(_contexts.input.inputEntity, birdFlyUpAction))
            .Add(new BirdSystems(_contexts, _gameLoop.PhysicsDeltaTime))

            .Add(new TestSystem(_contexts))

            .Add(new TransformSystems(_contexts.level, _gameLoop.PhysicsDeltaTime))
            .Add(new CollisionCleanupSystem(_contexts.level))
            .Add(new InputCleanupSystem(inputEntity));

        _physicsSystems.Initialize();
    }

    private void PhysicsUpdate()
    {
        _physicsSystems.Execute();
    }

    private void GraphicsUpdate()
    {

    }

    private void Dispose()
    {
        _physicsSystems.Cleanup();
        _graphicsSystems.Cleanup();

        _gameLoop.OnPhysicsUpdate -= PhysicsUpdate;
        _gameLoop.OnGraphicsUpdate -= GraphicsUpdate;
        _gameLoop.OnDispose -= Dispose;
    }
}
