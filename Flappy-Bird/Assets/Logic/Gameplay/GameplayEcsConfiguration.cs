using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
using System;

namespace FlappyBird
{
    [Serializable]
    public struct GameplayEcsConfiguration
    {
        public BirdConfiguration BirdConfiguration;
        public PipesConfiguration PipesConfiguration;
    }
}