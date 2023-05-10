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

        public SceneLoadingConfiguration LevelLoadingConfiguration
            => _levelLoadingConfiguration;

        public BirdConfiguration BirdConfiguration
            => _birdConfiguration;
    }
}
