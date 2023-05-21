//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LevelEntity {

    public FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent horizontalVelocity { get { return (FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent)GetComponent(LevelComponentsLookup.HorizontalVelocity); } }
    public bool hasHorizontalVelocity { get { return HasComponent(LevelComponentsLookup.HorizontalVelocity); } }

    public void AddHorizontalVelocity(float newValue) {
        var index = LevelComponentsLookup.HorizontalVelocity;
        var component = (FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHorizontalVelocity(float newValue) {
        var index = LevelComponentsLookup.HorizontalVelocity;
        var component = (FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.Transforms.HorizontalVelocityComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHorizontalVelocity() {
        RemoveComponent(LevelComponentsLookup.HorizontalVelocity);
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
public sealed partial class LevelMatcher {

    static Entitas.IMatcher<LevelEntity> _matcherHorizontalVelocity;

    public static Entitas.IMatcher<LevelEntity> HorizontalVelocity {
        get {
            if (_matcherHorizontalVelocity == null) {
                var matcher = (Entitas.Matcher<LevelEntity>)Entitas.Matcher<LevelEntity>.AllOf(LevelComponentsLookup.HorizontalVelocity);
                matcher.componentNames = LevelComponentsLookup.componentNames;
                _matcherHorizontalVelocity = matcher;
            }

            return _matcherHorizontalVelocity;
        }
    }
}
