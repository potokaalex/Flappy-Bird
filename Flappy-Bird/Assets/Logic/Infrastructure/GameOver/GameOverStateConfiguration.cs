using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public struct GameOverStateConfiguration : IStateParameter
    {
        public GameplayUI GameplayUI;
        public GameOverUI GameOverUI;
    }
}