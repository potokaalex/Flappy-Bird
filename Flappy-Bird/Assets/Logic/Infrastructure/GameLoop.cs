using FlappyBird.Extensions;
using UnityEngine;
using System;

namespace FlappyBird.Infrastructure
{
    public class GameLoop : MonoBehaviour
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnDispose;

        public DeltaTime FixedDeltaTime { get; private set; }

        public DeltaTime DeltaTime { get; private set; }

        private void Awake()
        {
            FixedDeltaTime = new();
            DeltaTime = new();
        }

        private void FixedUpdate()
        {
            FixedDeltaTime.SetValue(Time.fixedDeltaTime);
            OnFixedUpdate?.Invoke();
        }

        private void Update()
        {
            DeltaTime.SetValue(Time.deltaTime);
            OnUpdate?.Invoke();
        }

        private void OnDisable()
            => OnDispose?.Invoke();
    }
}
