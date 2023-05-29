using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using System;
using FlappyBird.Infrastructure;

namespace FlappyBird
{
    [Serializable]
    public class DataProvider
    {
        private DataProviderConfiguration _config;

        public SceneLoadingConfiguration LevelLoadingConfig
            => _config.LevelLoadingConfig;

        public BirdConfiguration BirdConfig
            => _config.BirdConfiguration;

        public PipesConfiguration PipesConfig
            => _config.PipesConfiguration;

        public PlayerProgress PlayerProgress
            => _config.PlayerProgress;

        public GameplayEcs Ecs
            => _config.Ecs;

        public void Initialize(DataProviderConfiguration config) 
            => _config = config;

        public GameOverStateConfiguration GameOverStateConfiguration;
    }
}