using System;

namespace FlappyBird
{
    public interface IGameLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnLateFixedUpdate;
        public event Action OnDispose;

        public DeltaTime FixedDeltaTime { get; }
    }
}