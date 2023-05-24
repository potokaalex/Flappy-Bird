using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using System;

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

        public EcsBase Ecs
            => _config.Ecs;

        public void Initialize(DataProviderConfiguration config) 
            => _config = config;
    }
}