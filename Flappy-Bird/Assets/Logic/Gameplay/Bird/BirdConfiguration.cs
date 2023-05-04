﻿using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Bird
{
    [Config, Unique]
    [Serializable]
    public class BirdConfiguration : IComponent
    {
        public Transform SpawnPoint;
        public GameObject Prefab;
        public float Acceleration;
        public float MaxVelocity;
        public float MinVelocity;
    }
}
