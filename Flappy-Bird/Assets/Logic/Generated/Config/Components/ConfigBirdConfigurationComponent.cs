//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity birdConfigurationEntity { get { return GetGroup(ConfigMatcher.BirdConfiguration).GetSingleEntity(); } }
    public FlappyBird.Gameplay.Bird.BirdConfiguration birdConfiguration { get { return birdConfigurationEntity.birdConfiguration; } }
    public bool hasBirdConfiguration { get { return birdConfigurationEntity != null; } }

    public ConfigEntity SetBirdConfiguration(UnityEngine.Transform newSpawnPoint, UnityEngine.GameObject newPrefab, float newAcceleration, float newMaxVelocity, float newMinVelocity) {
        if (hasBirdConfiguration) {
            throw new Entitas.EntitasException("Could not set BirdConfiguration!\n" + this + " already has an entity with FlappyBird.Gameplay.Bird.BirdConfiguration!",
                "You should check if the context already has a birdConfigurationEntity before setting it or use context.ReplaceBirdConfiguration().");
        }
        var entity = CreateEntity();
        entity.AddBirdConfiguration(newSpawnPoint, newPrefab, newAcceleration, newMaxVelocity, newMinVelocity);
        return entity;
    }

    public void ReplaceBirdConfiguration(UnityEngine.Transform newSpawnPoint, UnityEngine.GameObject newPrefab, float newAcceleration, float newMaxVelocity, float newMinVelocity) {
        var entity = birdConfigurationEntity;
        if (entity == null) {
            entity = SetBirdConfiguration(newSpawnPoint, newPrefab, newAcceleration, newMaxVelocity, newMinVelocity);
        } else {
            entity.ReplaceBirdConfiguration(newSpawnPoint, newPrefab, newAcceleration, newMaxVelocity, newMinVelocity);
        }
    }

    public void RemoveBirdConfiguration() {
        birdConfigurationEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigEntity {

    public FlappyBird.Gameplay.Bird.BirdConfiguration birdConfiguration { get { return (FlappyBird.Gameplay.Bird.BirdConfiguration)GetComponent(ConfigComponentsLookup.BirdConfiguration); } }
    public bool hasBirdConfiguration { get { return HasComponent(ConfigComponentsLookup.BirdConfiguration); } }

    public void AddBirdConfiguration(UnityEngine.Transform newSpawnPoint, UnityEngine.GameObject newPrefab, float newAcceleration, float newMaxVelocity, float newMinVelocity) {
        var index = ConfigComponentsLookup.BirdConfiguration;
        var component = (FlappyBird.Gameplay.Bird.BirdConfiguration)CreateComponent(index, typeof(FlappyBird.Gameplay.Bird.BirdConfiguration));
        component.SpawnPoint = newSpawnPoint;
        component.Prefab = newPrefab;
        component.Acceleration = newAcceleration;
        component.MaxVelocity = newMaxVelocity;
        component.MinVelocity = newMinVelocity;
        AddComponent(index, component);
    }

    public void ReplaceBirdConfiguration(UnityEngine.Transform newSpawnPoint, UnityEngine.GameObject newPrefab, float newAcceleration, float newMaxVelocity, float newMinVelocity) {
        var index = ConfigComponentsLookup.BirdConfiguration;
        var component = (FlappyBird.Gameplay.Bird.BirdConfiguration)CreateComponent(index, typeof(FlappyBird.Gameplay.Bird.BirdConfiguration));
        component.SpawnPoint = newSpawnPoint;
        component.Prefab = newPrefab;
        component.Acceleration = newAcceleration;
        component.MaxVelocity = newMaxVelocity;
        component.MinVelocity = newMinVelocity;
        ReplaceComponent(index, component);
    }

    public void RemoveBirdConfiguration() {
        RemoveComponent(ConfigComponentsLookup.BirdConfiguration);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherBirdConfiguration;

    public static Entitas.IMatcher<ConfigEntity> BirdConfiguration {
        get {
            if (_matcherBirdConfiguration == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.BirdConfiguration);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherBirdConfiguration = matcher;
            }

            return _matcherBirdConfiguration;
        }
    }
}
