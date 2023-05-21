using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using UnityEngine;
using System;

namespace FlappyBird
{
    [Serializable]
    public class DataProvider
    {
        [SerializeField] private SceneLoadingConfiguration _levelLoadingConfiguration;
        [SerializeField] private BirdConfiguration _birdConfiguration;
        [SerializeField] private PipesConfiguration _pipesConfiguration;

        public SceneLoadingConfiguration LevelLoadingConfiguration
            => _levelLoadingConfiguration;

        public BirdConfiguration BirdConfiguration
            => _birdConfiguration;

        public PipesConfiguration PipesConfiguration
            => _pipesConfiguration;

        public EcsBase Ecs { get; private set; }

        public void Initialize(EcsBase ecs)
        {
            Ecs = ecs;
        }
    }
}