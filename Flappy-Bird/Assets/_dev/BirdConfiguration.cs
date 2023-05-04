using System;
using UnityEngine;

[Serializable]
public class BirdConfiguration
{
    [SerializeField] private Transform _spawnPoint;

    public GameObject Prefab;
    public float InstanceRotation;

    public Vector2 InstancePosition
        => _spawnPoint.transform.position;

}
