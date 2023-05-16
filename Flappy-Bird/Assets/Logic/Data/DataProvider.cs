using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
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
    }
}