using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public class LevelSceneData : IData
    {
        public GameplayUI GameplayUI;
        public GameOverUI GameOverUI;
    }
}