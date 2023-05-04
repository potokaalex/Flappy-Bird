using UnityEngine;

using Object = UnityEngine.Object;

public class BirdFactory
{
    private BirdConfiguration _configuration;
    private Contexts _contexts;

    public BirdFactory(Contexts contexts, BirdConfiguration birdConfiguration)
    {
        _configuration = birdConfiguration;
        _contexts = contexts;
    }

    public void Create()
    {
        var gameObject = Object.Instantiate(_configuration.Prefab);
        var entity = _contexts.game.CreateEntity();

        entity.AddLinkToGameObject(gameObject);
        entity.AddPosition(_configuration.InstancePosition);
        entity.AddRotation(_configuration.InstanceRotation);
        entity.AddVelocity(Vector2.zero);
    }
}
