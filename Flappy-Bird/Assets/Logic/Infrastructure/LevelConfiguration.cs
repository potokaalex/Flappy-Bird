using UnityEngine.InputSystem;
using UnityEngine;
using FlappyBird.StateMachine;
using System;

[Serializable]
public struct LevelConfiguration : IStateParameter
{
    public InputAction FlyUpAction;//load
    public GameObject BirdPrefab;//load
    public Transform BirdSpawnPoint;
}