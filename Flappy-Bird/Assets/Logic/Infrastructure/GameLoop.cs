using FlappyBird.Gameplay.Common;
using UnityEngine;
using System;

public class GameLoop : MonoBehaviour
{
    public event Action OnPhysicsUpdate;
    public event Action OnGraphicsUpdate;
    public event Action OnDispose;

    public DeltaTime PhysicsDeltaTime { get; private set; }

    public DeltaTime GraphicsDeltaTime { get; private set; }

    public bool IsPause { get; set; }

    private void Awake()
    {
        PhysicsDeltaTime = new();
        GraphicsDeltaTime = new();
    }

    private void FixedUpdate()
    {
        if (!IsPause)
        {
            PhysicsDeltaTime.SetValue(Time.fixedDeltaTime);
            OnPhysicsUpdate?.Invoke();
        }
    }

    private void Update()
    {
        GraphicsDeltaTime.SetValue(Time.deltaTime);
        OnGraphicsUpdate?.Invoke();
    }

    private void OnDisable()
        => OnDispose?.Invoke();
}
