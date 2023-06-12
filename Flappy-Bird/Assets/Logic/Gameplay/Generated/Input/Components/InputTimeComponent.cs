//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity timeEntity { get { return GetGroup(InputMatcher.Time).GetSingleEntity(); } }
    public FlappyBird.Gameplay.Core.TimeComponent time { get { return timeEntity.time; } }
    public bool hasTime { get { return timeEntity != null; } }

    public InputEntity SetTime(float newDeltaTime) {
        if (hasTime) {
            throw new Entitas.EntitasException("Could not set Time!\n" + this + " already has an entity with FlappyBird.Gameplay.Core.TimeComponent!",
                "You should check if the context already has a timeEntity before setting it or use context.ReplaceTime().");
        }
        var entity = CreateEntity();
        entity.AddTime(newDeltaTime);
        return entity;
    }

    public void ReplaceTime(float newDeltaTime) {
        var entity = timeEntity;
        if (entity == null) {
            entity = SetTime(newDeltaTime);
        } else {
            entity.ReplaceTime(newDeltaTime);
        }
    }

    public void RemoveTime() {
        timeEntity.Destroy();
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
public partial class InputEntity {

    public FlappyBird.Gameplay.Core.TimeComponent time { get { return (FlappyBird.Gameplay.Core.TimeComponent)GetComponent(InputComponentsLookup.Time); } }
    public bool hasTime { get { return HasComponent(InputComponentsLookup.Time); } }

    public void AddTime(float newDeltaTime) {
        var index = InputComponentsLookup.Time;
        var component = (FlappyBird.Gameplay.Core.TimeComponent)CreateComponent(index, typeof(FlappyBird.Gameplay.Core.TimeComponent));
        component.DeltaTime = newDeltaTime;
        AddComponent(index, component);
    }

    public void ReplaceTime(float newDeltaTime) {
        var index = InputComponentsLookup.Time;
        var component = (FlappyBird.Gameplay.Core.TimeComponent)CreateComponent(index, typeof(FlappyBird.Gameplay.Core.TimeComponent));
        component.DeltaTime = newDeltaTime;
        ReplaceComponent(index, component);
    }

    public void RemoveTime() {
        RemoveComponent(InputComponentsLookup.Time);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherTime;

    public static Entitas.IMatcher<InputEntity> Time {
        get {
            if (_matcherTime == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Time);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTime = matcher;
            }

            return _matcherTime;
        }
    }
}
