using UnityEngine;
using System;

namespace FlappyBird
{
    public class GameLoop : MonoBehaviour, IGameLoop
    {
        public event Action OnFixedUpdate;

        public DeltaTime FixedDeltaTime { get; private set; }

        private void Awake()
            => FixedDeltaTime = new();

        private void FixedUpdate()
        {
            FixedDeltaTime.Value = Time.fixedDeltaTime;
            OnFixedUpdate?.Invoke();
        }
    }
}