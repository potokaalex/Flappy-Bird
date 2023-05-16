using System;

namespace FlappyBird
{
    public interface IGameLoop
    {
        public event Action OnFixedUpdate;

        public DeltaTime FixedDeltaTime { get; }
    }
}
