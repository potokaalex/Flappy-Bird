using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public class GameOverStateConfiguration : IStateParameter, IData
    {
        public GameplayUI GameplayUI;
        public GameOverUI GameOverUI;
    }
}