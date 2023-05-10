using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public struct LevelStateConfiguration : IStateParameter
    {
        public InputAction FlyUpAction;//load
        public GameObject BirdPrefab;//load
        public Transform BirdSpawnPoint;
    }
}
