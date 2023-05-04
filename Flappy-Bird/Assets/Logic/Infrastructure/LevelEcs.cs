using Entitas;
using UnityEngine;
using FlappyBird.Gameplay.Transforms;
using FlappyBird.Gameplay.Bird;

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
        var entity = _contexts.config.CreateEntity();

        entity.AddBirdConfiguration(birdConfiguration.SpawnPoint, birdConfiguration.Prefab,
            birdConfiguration.Acceleration, birdConfiguration.MaxVelocity, birdConfiguration.MinVelocity);
    }

    public void InitializeEntities()
    {
        var birdFactory = new BirdFactory(_contexts);
        birdFactory.Create();
    }

    public void InitializeSystems()
    {
        _physicsSystems
            .Add(new TransformSystems(_contexts, _gameLoop.PhysicsDeltaTime))
            .Add(new BirdGravitySystem(_contexts, _gameLoop.PhysicsDeltaTime));

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
