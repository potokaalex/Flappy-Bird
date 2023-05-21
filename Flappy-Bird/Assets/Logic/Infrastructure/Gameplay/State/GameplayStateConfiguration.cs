using UnityEngine;
using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public struct GameplayStateConfiguration : IStateParameter
    {
        public Transform BirdSpawnPoint;
    }
}
