using System.Collections.Generic;
using UnityEngine;
using Entitas;
using FlappyBird;

public class TestSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    //private readonly DataProvider _data;

    public TestSystem(Contexts contexts, DataProvider data)
    {
        _contexts = contexts;
        //_data = data;

        data.PlayerProgress.Score.OnCurrentScoreChanged += DisplayScore;
    }

    public void Execute()
    {
    }

    private void DisplayScore(float score)
        => Debug.Log(score);
}