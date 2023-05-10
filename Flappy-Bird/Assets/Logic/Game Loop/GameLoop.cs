using UnityEngine;
using System;

namespace FlappyBird
{
    public class GameLoop : MonoBehaviour, IGameLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;

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
    }
}
