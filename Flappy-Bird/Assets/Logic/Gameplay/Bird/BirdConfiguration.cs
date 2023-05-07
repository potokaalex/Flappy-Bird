using Entitas.CodeGeneration.Attributes;
using UnityEngine.InputSystem;
using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Bird
{
    [Configs, Unique]
    [Serializable]
    public class BirdConfiguration : IComponent
    {
        public Transform SpawnPoint;
        public GameObject Prefab;
        public InputAction FlyUpAction;
        public float Acceleration;
        public float MaxVelocity;
        public float MinVelocity;
    }
}
