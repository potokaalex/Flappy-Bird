using UnityEngine;
using System;

namespace FlappyBird
{
    public class GameLoop : MonoBehaviour, IGameLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnLateFixedUpdate;
        public event Action OnDispose;

        public DeltaTime FixedDeltaTime { get; private set; }

        private void Awake()
            => FixedDeltaTime = new();

        private void FixedUpdate()
        {
            FixedDeltaTime.Value = Time.fixedDeltaTime;
            OnFixedUpdate?.Invoke();
            OnLateFixedUpdate?.Invoke();
        }

        private void OnDisable()
            => OnDispose?.Invoke();
    }
}