//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity collisionEntity { get { return GetGroup(InputMatcher.Collision).GetSingleEntity(); } }
    public FlappyBird.Ecs.Basic.Collision.CollisionComponent collision { get { return collisionEntity.collision; } }
    public bool hasCollision { get { return collisionEntity != null; } }

    public InputEntity SetCollision(UnityEngine.Collision2D newInfo) {
        if (hasCollision) {
            throw new Entitas.EntitasException("Could not set Collision!\n" + this + " already has an entity with FlappyBird.Ecs.Basic.Collision.CollisionComponent!",
                "You should check if the context already has a collisionEntity before setting it or use context.ReplaceCollision().");
        }
        var entity = CreateEntity();
        entity.AddCollision(newInfo);
        return entity;
    }

    public void ReplaceCollision(UnityEngine.Collision2D newInfo) {
        var entity = collisionEntity;
        if (entity == null) {
            entity = SetCollision(newInfo);
        } else {
            entity.ReplaceCollision(newInfo);
        }
    }

    public void RemoveCollision() {
        collisionEntity.Destroy();
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

    public FlappyBird.Ecs.Basic.Collision.CollisionComponent collision { get { return (FlappyBird.Ecs.Basic.Collision.CollisionComponent)GetComponent(InputComponentsLookup.Collision); } }
    public bool hasCollision { get { return HasComponent(InputComponentsLookup.Collision); } }

    public void AddCollision(UnityEngine.Collision2D newInfo) {
        var index = InputComponentsLookup.Collision;
        var component = (FlappyBird.Ecs.Basic.Collision.CollisionComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.Collision.CollisionComponent));
        component.Info = newInfo;
        AddComponent(index, component);
    }

    public void ReplaceCollision(UnityEngine.Collision2D newInfo) {
        var index = InputComponentsLookup.Collision;
        var component = (FlappyBird.Ecs.Basic.Collision.CollisionComponent)CreateComponent(index, typeof(FlappyBird.Ecs.Basic.Collision.CollisionComponent));
        component.Info = newInfo;
        ReplaceComponent(index, component);
    }

    public void RemoveCollision() {
        RemoveComponent(InputComponentsLookup.Collision);
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

    static Entitas.IMatcher<InputEntity> _matcherCollision;

    public static Entitas.IMatcher<InputEntity> Collision {
        get {
            if (_matcherCollision == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Collision);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCollision = matcher;
            }

            return _matcherCollision;
        }
    }
}
