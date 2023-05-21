//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LevelEntity {

    public FlappyBird.Ecs.Basic.LinkToGameObjectComponent linkToGameObject { get { return (FlappyBird.Ecs.Basic.LinkToGameObjectComponent)GetComponent(LevelComponentsLookup.LinkToGameObject); } }
    public bool hasLinkToGameObject { get { return HasComponent(LevelComponentsLookup.LinkToGameObject); } }

    public void AddLinkToGameObject(UnityEngine.GameObject newGameObject) {
        var index = LevelComponentsLookup.LinkToGameObject;
        var component = (FlappyBird.Ecs.Basic.LinkToGameObjectComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.LinkToGameObjectComponent));
        component.GameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceLinkToGameObject(UnityEngine.GameObject newGameObject) {
        var index = LevelComponentsLookup.LinkToGameObject;
        var component = (FlappyBird.Ecs.Basic.LinkToGameObjectComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.LinkToGameObjectComponent));
        component.GameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveLinkToGameObject() {
        RemoveComponent(LevelComponentsLookup.LinkToGameObject);
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

    static Entitas.IMatcher<LevelEntity> _matcherLinkToGameObject;

    public static Entitas.IMatcher<LevelEntity> LinkToGameObject {
        get {
            if (_matcherLinkToGameObject == null) {
                var matcher = (Entitas.Matcher<LevelEntity>)Entitas.Matcher<LevelEntity>.AllOf(LevelComponentsLookup.LinkToGameObject);
                matcher.componentNames = LevelComponentsLookup.componentNames;
                _matcherLinkToGameObject = matcher;
            }

            return _matcherLinkToGameObject;
        }
    }
}
