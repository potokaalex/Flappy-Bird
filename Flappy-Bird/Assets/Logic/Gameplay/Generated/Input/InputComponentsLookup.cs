//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class InputComponentsLookup {

    public const int Collision = 0;
    public const int Event = 1;
    public const int Time = 2;
    public const int BirdData = 3;
    public const int FlyUp = 4;
    public const int PipesData = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Collision",
        "Event",
        "Time",
        "BirdData",
        "FlyUp",
        "PipesData"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(FlappyBird.Gameplay.Basic.CollisionComponent),
        typeof(FlappyBird.Gameplay.Basic.EventComponent),
        typeof(FlappyBird.Gameplay.Basic.TimeComponent),
        typeof(FlappyBird.Gameplay.Bird.BirdDataComponent),
        typeof(FlappyBird.Gameplay.Bird.FlyUpComponent),
        typeof(FlappyBird.Gameplay.Pipes.PipesDataComponent)
    };
}
