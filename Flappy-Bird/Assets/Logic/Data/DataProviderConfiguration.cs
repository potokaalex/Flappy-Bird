using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using System;

namespace FlappyBird
{
    [Serializable]
    public class DataProviderConfiguration
    {
        public BirdConfiguration BirdConfiguration;
        public PipesConfiguration PipesConfiguration;
        public SceneLoadingConfiguration LevelLoadingConfig;
        public PlayerProgress PlayerProgress;
        public GameplayEcs Ecs;
    }
}