using System;

namespace FlappyBird
{
    public interface IGameLoop
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;

        public DeltaTime FixedDeltaTime { get; }

        public DeltaTime DeltaTime { get; }
    }
}
