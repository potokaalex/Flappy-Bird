//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LevelEntity {

    static readonly FlappyBird.Gameplay.Pipes.PipesComponent pipesComponent = new FlappyBird.Gameplay.Pipes.PipesComponent();

    public bool isPipes {
        get { return HasComponent(LevelComponentsLookup.Pipes); }
        set {
            if (value != isPipes) {
                var index = LevelComponentsLookup.Pipes;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pipesComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<LevelEntity> _matcherPipes;

    public static Entitas.IMatcher<LevelEntity> Pipes {
        get {
            if (_matcherPipes == null) {
                var matcher = (Entitas.Matcher<LevelEntity>)Entitas.Matcher<LevelEntity>.AllOf(LevelComponentsLookup.Pipes);
                matcher.componentNames = LevelComponentsLookup.componentNames;
                _matcherPipes = matcher;
            }

            return _matcherPipes;
        }
    }
}
