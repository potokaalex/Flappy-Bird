using System;

namespace FlappyBird.Infrastructure
{
    [Serializable]
    public class UISceneData : IData
    {
        public GameplayUI GameplayUI;
        public GameOverUI GameOverUI;
    }
}