using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TestSystem : IExecuteSystem, ICleanupSystem
{
    private Contexts _contexts;
    private List<Vector2> _positions;

    public TestSystem(Contexts contexts)
    {
        _contexts = contexts;
        _positions = new(100);
    }

    public void Execute()
    {
        _positions.Add(_contexts.level.birdEntity.position.Value);
    }

    public void Cleanup()
    {
        var highestY = float.MinValue;

        foreach (var position in _positions)
        {
            if (position.y > highestY)
                highestY = position.y;
        }

        Debug.Log(highestY);
    }
}