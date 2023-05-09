using System.Collections.Generic;
using UnityEngine;
using Entitas;
using FlappyBird.Extensions;

public class TestSystem : IExecuteSystem
{
    private Contexts _contexts;

    public TestSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (_contexts.input.inputEntity.isFlyUp)
            Debug.Log("Fly!");
    }
}
