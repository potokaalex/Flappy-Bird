using UnityEngine;
using System;

namespace FlappyBird.Gameplay.Core.Pipes
{
    [Serializable]
    public class PipesSceneData : IData
    {
        public Transform PipesSpawnPoint;
    }
}