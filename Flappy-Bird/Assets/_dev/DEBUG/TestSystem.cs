using System.Collections.Generic;
using UnityEngine;
using Entitas;
using FlappyBird;

public class TestSystem : IInitializeSystem, IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly DataProvider _data;

    public TestSystem(Contexts contexts, IStateMachine stateMachine, IGameLoop gameLoop)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
    }
    
    public void Execute()
    {
    }
}