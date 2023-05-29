using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Ecs.Gameplay.Pipes;
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