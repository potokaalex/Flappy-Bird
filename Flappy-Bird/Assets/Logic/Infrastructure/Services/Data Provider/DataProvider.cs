using FlappyBird.Gameplay;
using FlappyBird.Infrastructure;

namespace FlappyBird
{
    public class DataProvider
    {
        public GameOverStateConfiguration GameOverStateConfiguration;

        public PlayerProgress Progress { get; } = new();
    }
}