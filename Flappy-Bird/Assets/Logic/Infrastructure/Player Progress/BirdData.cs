using FlappyBird.Gameplay.Bird;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyBird
{
    public class BirdData
    {
        public BirdConfiguration StaticData;
        public InputAction BirdFlyUpAction;
        public GameObject BirdPrefab;
        public Vector2 BirdSpawnPoint;
    }
}