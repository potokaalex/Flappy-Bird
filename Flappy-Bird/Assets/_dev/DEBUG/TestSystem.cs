using System.Collections.Generic;
using UnityEngine;
using Entitas;
using FlappyBird;

public class TestSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly DataProvider _data;

    public TestSystem(Contexts contexts, DataProvider data,
        IStateMachine stateMachine, IGameLoop gameLoop)
    {
        _contexts = contexts;
        _data = data;
    }

    public void Execute()
    {
    }
}