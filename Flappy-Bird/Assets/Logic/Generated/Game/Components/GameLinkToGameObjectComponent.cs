//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FlappyBird.Gameplay.Common.LinkToGameObject linkToGameObject { get { return (FlappyBird.Gameplay.Common.LinkToGameObject)GetComponent(GameComponentsLookup.LinkToGameObject); } }
    public bool hasLinkToGameObject { get { return HasComponent(GameComponentsLookup.LinkToGameObject); } }

    public void AddLinkToGameObject(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.LinkToGameObject;
        var component = (FlappyBird.Gameplay.Common.LinkToGameObject)CreateComponent(index, typeof(FlappyBird.Gameplay.Common.LinkToGameObject));
        component.GameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceLinkToGameObject(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.LinkToGameObject;
        var component = (FlappyBird.Gameplay.Common.LinkToGameObject)CreateComponent(index, typeof(FlappyBird.Gameplay.Common.LinkToGameObject));
        component.GameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveLinkToGameObject() {
        RemoveComponent(GameComponentsLookup.LinkToGameObject);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLinkToGameObject;

    public static Entitas.IMatcher<GameEntity> LinkToGameObject {
        get {
            if (_matcherLinkToGameObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LinkToGameObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLinkToGameObject = matcher;
            }

            return _matcherLinkToGameObject;
        }
    }
}
