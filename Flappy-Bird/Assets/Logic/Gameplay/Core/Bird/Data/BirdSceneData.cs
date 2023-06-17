using UnityEngine;
using System;

namespace FlappyBird.Gameplay.Core.Bird
{
    [Serializable]
    public class BirdSceneData : IData
    {
        public Transform BirdSpawnPoint;
    }
}