using FlappyBird.Gameplay.Core.Bird;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyBird
{
    public class BirdData
    {
        public BirdStaticData StaticData;
        public InputAction BirdFlyUpAction;
        public GameObject BirdPrefab;
        public Vector2 BirdSpawnPoint;
    }
}